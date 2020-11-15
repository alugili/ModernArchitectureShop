using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Infrastructure.ServiceCollection;
using Serilog;

namespace ModernArchitectureShop.BasketApi
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
                Log.Information($"Starting up Basket API");
                CreateHostBuilder(args).Build().CreateDatabase<IItemRepository>().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Basket API start-up failed");
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
