using System.Collections.Generic;
using ModernArchitectureShop.StoreApi.Infrastructure.Dto;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetStores
{
    public class GetStoresResponse
    {
        public IEnumerable<StoreDto> Stores { get; set; }

        public int TotalRecords { get; set; }
    }
}
