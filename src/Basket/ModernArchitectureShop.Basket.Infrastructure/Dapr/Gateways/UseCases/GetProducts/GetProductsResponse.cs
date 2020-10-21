using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Gateways.UseCases.GetProducts
{
    public class GetProductsResponse
    {
        public IEnumerable<ProductResult> Products { get; set; } = new ProductResult[0];

        public class ProductResult
        {
            public Guid Id { get; set; }
            public string Code { get; set; } = string.Empty;

            public IEnumerable<ProductStoreResult> Stores { get; set; } = new ProductStoreResult[0];
        }

        public class ProductStoreResult
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public bool CanPurchase { get; set; }
        }
    }
}
