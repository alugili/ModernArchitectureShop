using System.Reflection;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Gateways;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers;
using ModernArchitectureShop.BasketApi.Infrastructure.Persistence;
using ModernArchitectureShop.BasketApi.ServiceCollection;


namespace ModernArchitectureShop.BasketApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration.GetValue<string>("IDENTITY_AUTHORITY");
                    options.RequireHttpsMetadata = Configuration.GetValue<bool>("IDENTITY_REQUIREHTTPSMETADATA");
                    options.Audience = Configuration.GetValue<string>("IDENTITY_AUDIENCE");
                });

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins(Configuration.GetValue<string>("BLAZOR_UI"))
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddCustomRequestValidation()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddCustomDapr();

            services
                .AddHttpContextAccessor()
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddDbContext<BasketDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services
                 .AddTransient<ItemCreatedNotificationHandler>()
                 .AddTransient<DaprStoresGateway>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles()
                .UseCloudEvents()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapSubscribeHandler();
                });

        }
    }
}
