using MediatR;
using ModernArchitectureShop.Order.Application.UseCases.GetOrder;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetCompletedOrders
{
    public class GetCompletedOrdersCommand : IRequest<GetCompletedOrdersResponse>, IGetCompletedOrders
    {
        public string Username { get; set; } = string.Empty;
    }
}
