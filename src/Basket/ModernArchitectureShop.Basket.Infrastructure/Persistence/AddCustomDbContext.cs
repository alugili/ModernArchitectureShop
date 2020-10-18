using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ModernArchitectureShop.Basket.Infrastructure.Persistence
{
    public static class CustomServiceCollectionExtenstion
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BasketDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
