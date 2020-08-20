using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.BasketApi.Validation;

namespace ModernArchitectureShop.BasketApi.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomRequestValidation(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
