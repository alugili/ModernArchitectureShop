using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dapr.Gateways;
using ModernArchitectureShop.Store.Infrastructure.Events;
using ModernArchitectureShop.Store.Infrastructure.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpContextAccessor()
                .AddCustomDbContext(configuration.GetConnectionString("SqlConnection"))
                .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IStoreRepository, StoreRepository>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddCustomRequestValidation()
                .AddCustomDapr()
                .AddTransient<DaprStoresGateway>();

            return services;
        }
    }
}
