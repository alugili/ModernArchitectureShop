using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
                options =>
                {
                    options.Authority = Configuration.GetValue<string>("IDENTITY_AUTHORITY");
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "BlazorUI";
                    options.ClientSecret = "secret";
                    options.UsePkce = true;
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.Scope.Add("offline_access");

                    //Scope for accessing API
                    options.Scope.Add(storeApiName); //invalid scope for client
                    options.Scope.Add(basketApiName); //invalid scope for client
                });

            services.AddAuthorization();

            services.AddHttpClient<ProductService, ProductService>(client =>
            {
                client.BaseAddress = new Uri(storeApiURL);
            });

            services.AddHttpClient<BasketProductService, BasketProductService>(client =>
            {
                client.BaseAddress = new Uri(basketApiURL);
            });

            services.AddHttpClient<IdentityService, IdentityService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("IDENTITY_AUTHORITY"));
            });
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

            //app.UseHttpsRedirection();
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
