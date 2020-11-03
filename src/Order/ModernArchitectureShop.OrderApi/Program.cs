using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Infrastructure.ServiceCollection;

namespace ModernArchitectureShop.OrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            CreateHostBuilder(args).Build().CreateDatabase<IOrderRepository>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
