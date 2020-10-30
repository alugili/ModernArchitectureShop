using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Logging;
using ModernArchitectureShop.BlazorUI.DaprClients;
using ModernArchitectureShop.BlazorUI.Services;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace ModernArchitectureShop.BlazorUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var storeApiURL = Configuration.GetValue<string>("STORE_URL");
            var storeApiName = Configuration.GetValue<string>("STORE_NAME");

            //Create an HTTP client for accessing the API.
            services.AddHttpClient(storeApiName, client =>
            {
                client.BaseAddress = new Uri(storeApiURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            var basketApiURL = Configuration.GetValue<string>("BASKET_URL");
            var basketApiName = Configuration.GetValue<string>("BASKET_NAME");

            services.AddHttpClient(basketApiName, client =>
            {
                client.BaseAddress = new Uri(basketApiURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";

                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = Configuration.GetValue<string>("IDENTITY_AUTHORITY");
                    options.ClientId = "BlazorUI";
                    options.ClientSecret = "secret";
                    options.RequireHttpsMetadata = false;

                    options.ResponseType = "code";

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.Scope.Add("offline_access");

                    options.UseTokenLifetime = true;

                    //Scope for accessing API
                    options.Scope.Add(storeApiName); //invalid scope for client
                    options.Scope.Add(basketApiName); //invalid scope for client
                    options.UsePkce = true;
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                });

            services.AddHttpClient<ProductsService>(client =>
            {
                client.BaseAddress = new Uri(storeApiURL);
            });

            services.AddHttpClient<BasketsService>(client =>
            {
                client.BaseAddress = new Uri(basketApiURL);
            });

            services.AddScoped<IdentityService, IdentityService>();
            services.AddScoped<ProductsDaprClient>();

            services.AddCustomDapr();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Todo only for test
            IdentityModelEventSource.ShowPII = true;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseCookiePolicy();

            //app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                // workaround IdentityServer4
                MinimumSameSitePolicy = SameSiteMode.Lax,
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }


    }
}
