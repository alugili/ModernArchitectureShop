using System;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Dto
{
    public class ProductStoreDto
    {
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public StoreDto Store { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
