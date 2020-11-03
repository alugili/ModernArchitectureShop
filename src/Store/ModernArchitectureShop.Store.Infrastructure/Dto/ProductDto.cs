using System;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; }= string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
        public Guid StoreId{ get; set; }
        public StoreDto Store { get; set; }
    }
}
