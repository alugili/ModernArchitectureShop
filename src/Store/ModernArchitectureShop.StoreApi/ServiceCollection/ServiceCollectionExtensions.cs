using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.StoreApi.Events;
using ModernArchitectureShop.StoreApi.Validation;

namespace ModernArchitectureShop.StoreApi.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomRequestValidation(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }

        public static IServiceCollection AddDomainEventDispatcher(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            return services;
        }
    }
}
