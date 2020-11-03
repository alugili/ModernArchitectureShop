using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStoreResponse
    {
        public StoreDto Store { get; set; } = new StoreDto();
    }
}
