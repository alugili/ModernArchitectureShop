using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Order.Infrastructure.Validation;

namespace ModernArchitectureShop.Order.Infrastructure.ServiceCollection
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
