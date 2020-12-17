using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.GetItems;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItems
{
    public class GetItemsCommand : IRequest<GetItemsResponse>, IGetItems
    {
        public string Username { get; set; } = string.Empty;
    }
}
