using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<ProductStoreDto> ProductStores { get; set; }
    }
}
