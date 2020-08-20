using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Dto
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<ProductStoreDto> Products { get; set; }
    }
}
