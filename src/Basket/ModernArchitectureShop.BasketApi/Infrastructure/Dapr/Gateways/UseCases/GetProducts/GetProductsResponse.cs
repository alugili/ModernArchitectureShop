using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Gateways.UseCases.GetProducts
{
    public class GetProductsResponse
    {
        public IEnumerable<ProductResult> Products { get; set; }

        public class ProductResult
        {
            public Guid Id { get; set; }
            public string Code { get; set; }

            public IEnumerable<ProductStoreResult> Stores { get; set; }
        }

        public class ProductStoreResult
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public int Quantity { get; set; }
            public bool CanPurchase { get; set; }
        }
    }
}
