using System;
using System.Collections.Generic;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds
{
    public class GetProductsByIdsResponse
    {
        public IEnumerable<ProductResult> Products { get; set; } = new ProductResult[0];

        public class ProductResult
        {
            public Guid Id { get; set; }

            public string Code { get; set; } = string.Empty;

            public ProductStoreResult Store { get; set; } = new ProductStoreResult();
        }

        public class ProductStoreResult
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public bool CanPurchase { get; set; }
            public StoreDto Store { get; set; }
        }
    }
}
