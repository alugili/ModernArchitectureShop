using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Store.Infrastructure.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.ServiceCollection
{
    public static class CustomServiceCollectionExtenstion
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreDbContext>(
                options => options.UseSqlServer(connectionString,
                providerOptions => providerOptions.EnableRetryOnFailure()));
            return services;
        }
    }
}
