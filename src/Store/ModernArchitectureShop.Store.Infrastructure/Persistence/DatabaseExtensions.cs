using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.Store.Application.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.Persistence
{
    public static class DatabaseExtensions
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : IStoreRepository
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var itemRepository = services.GetRequiredService<T>();
                itemRepository.SeedDatabase();
            }

            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<ShopUI.Program>>();
                logger.LogError(ex, ex.StackTrace);
            }

            return webHost;
        }
    }
}
