using System.Collections.Generic;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStoresResponse
    {
        public IEnumerable<StoreDto> Stores { get; set; } = new StoreDto[0];

        public int TotalRecords { get; set; }
    }
}
