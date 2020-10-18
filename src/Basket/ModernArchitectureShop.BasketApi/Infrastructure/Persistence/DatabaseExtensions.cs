using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.Basket.Application.Persistence;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Persistence
{
    public static class DatabaseExtensions
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : IItemRepository
        {
            using (var scope = webHost.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
                try
                {
                    var itemRepository = services.GetRequiredService<T>();
                    itemRepository.CreateDatabase();
                }

                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, ex.StackTrace);
                }
            }

            return webHost;
        }
    }
}
