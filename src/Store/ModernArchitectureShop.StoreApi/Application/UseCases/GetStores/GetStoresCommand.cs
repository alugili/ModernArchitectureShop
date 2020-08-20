using MediatR;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetStores
{
    public class GetStoresCommand : IRequest<GetStoresResponse>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
