using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ModernArchitectureShop.Order.Infrastructure.Persistence
{
    public static class CustomServiceCollectionExtenstion
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OrderDbContext>(
                options => options.UseSqlServer(connectionString,
                    providerOptions => providerOptions.EnableRetryOnFailure()));
                


            return services;
        }
    }
}
