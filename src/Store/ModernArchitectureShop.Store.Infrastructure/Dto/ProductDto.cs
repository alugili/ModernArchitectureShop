using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; }= string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public IEnumerable<ProductStoreDto> ProductStores { get; set; } = new ProductStoreDto[0];
    }
}
