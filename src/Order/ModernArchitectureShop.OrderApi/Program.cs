using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Infrastructure.ServiceCollection;
using Serilog;

namespace ModernArchitectureShop.OrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information($"Starting up Order API");
                CreateHostBuilder(args).Build().CreateDatabase<IOrderRepository>().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Order API start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
