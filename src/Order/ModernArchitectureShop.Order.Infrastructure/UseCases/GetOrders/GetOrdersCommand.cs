using MediatR;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetOrders
{
    public class GetOrdersCommand : IRequest<GetOrdersResponse>, IGetOrders
    {
        public string Username { get; set; } = string.Empty;
    }
}
