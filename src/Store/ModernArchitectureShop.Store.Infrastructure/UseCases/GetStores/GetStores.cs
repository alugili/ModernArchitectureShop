using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.GetStores;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStores : IRequest<GetStoresResponse>, IGetStores
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
