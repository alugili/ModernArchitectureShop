using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Persistence;
using Serilog;

namespace ModernArchitectureShop.StoreApi
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
                Log.Information($"Starting up Store API");
                CreateHostBuilder(args).Build().CreateDatabase<IStoreRepository>().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Store API start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                //.WriteTo.Seq(
                //    Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341")
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
