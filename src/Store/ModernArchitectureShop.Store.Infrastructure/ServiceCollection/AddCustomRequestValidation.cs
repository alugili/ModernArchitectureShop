using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Store.Infrastructure.Validation;

namespace ModernArchitectureShop.Store.Infrastructure.ServiceCollection
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
