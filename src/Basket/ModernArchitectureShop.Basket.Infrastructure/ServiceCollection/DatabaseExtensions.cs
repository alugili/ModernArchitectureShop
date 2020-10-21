using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Basket.Application.Persistence;

namespace ModernArchitectureShop.Basket.Infrastructure.ServiceCollection
{
    public static class DatabaseExtensions
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : IItemRepository
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var itemRepository = services.GetRequiredService<T>();
            itemRepository.CreateDatabase();

            return webHost;
        }
    }
}
