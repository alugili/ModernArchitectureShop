using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Infrastructure.Persistence;

namespace ModernArchitectureShop.Order.Infrastructure.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpContextAccessor()
                .AddCustomDbContext(configuration.GetConnectionString("SqlConnection"))
                .AddTransient<IOrderRepository, OrderRepository>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddCustomRequestValidation()
                .AddCustomDapr();

            return services;
        }
    }
}
