using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernArchitectureShop.Order.Application.Persistence;

namespace ModernArchitectureShop.Order.Infrastructure.ServiceCollection
{
    public static class DatabaseExtensions
    {
        public static IHost CreateDatabase<T>(this IHost webHost) where T : IOrderRepository
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var orderRepository = services.GetRequiredService<T>();
            orderRepository.CreateDatabase();

            return webHost;
        }
    }
}
