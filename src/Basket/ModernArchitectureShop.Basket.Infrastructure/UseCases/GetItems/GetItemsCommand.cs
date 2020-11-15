using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.GetItems;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItems
{
    public class GetItemsCommand : IRequest<GetItemsResponse>, IGetItems
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Username { get; set; } = string.Empty;
    }
}
