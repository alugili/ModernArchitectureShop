using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Basket.Infrastructure.Validation;

namespace ModernArchitectureShop.Basket.Infrastructure.ServiceCollection
{
    public static class CustomRequestValidationExtenstion
    {
        public static IServiceCollection AddCustomRequestValidation(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
