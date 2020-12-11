using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using ModernArchitectureShop.Basket.Infrastructure.Dapr.Gateways;
using ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers;

namespace ModernArchitectureShop.Basket.Infrastructure.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpContextAccessor()
                .AddCustomDbContext(configuration.GetConnectionString("SqlConnection"))
                .AddTransient<IBasketRepository, BasketRepository>()
                .AddTransient<IItemRepository, ItemRepository>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddCustomRequestValidation()
                .AddCustomDapr()
                .AddTransient<BasketItemNotificationHandler>()
                .AddTransient<DaprBasketGateway>();

            return services;
        }
    }
}
