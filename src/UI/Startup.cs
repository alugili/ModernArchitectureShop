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
using ModernArchitectureShop.BlazorUI.Services;

namespace ModernArchitectureShop.BlazorUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

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


                    options.ResponseType = "code";

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.Scope.Add("offline_access");

                    //Scope for accessing API
                    options.Scope.Add(storeApiName); //invalid scope for client
                    options.Scope.Add(basketApiName); //invalid scope for client
                    options.UsePkce = true;
                    options.SaveTokens = true;
                });

            services.AddHttpClient<ProductService, ProductService>(client =>
            {
                client.BaseAddress = new Uri(storeApiURL);
            });

            services.AddHttpClient<BasketProductService, BasketProductService>(client =>
            {
                client.BaseAddress = new Uri(basketApiURL);
            });

            services.AddSingleton<BlazorServerAuthStateCache>();
            services.AddScoped<AuthenticationStateProvider, BlazorServerAuthState>();
            services.AddScoped<IdentityService, IdentityService>();

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
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
