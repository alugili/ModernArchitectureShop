using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Store.Application.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.Persistence
{
    public static class DatabaseExtensions
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : IStoreRepository
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var itemRepository = services.GetRequiredService<T>();
            itemRepository.SeedDatabase();
            return webHost;
        }
    }
}
