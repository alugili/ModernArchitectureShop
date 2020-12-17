using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.GetItemsInPage;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItemsPage
{
    public class GetItemsPageCommand : IRequest<GetItemsPageResponse>, IGetItemsPage
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Username { get; set; } = string.Empty;
    }
}
