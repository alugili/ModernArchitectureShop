using System;

namespace ModernArchitectureShop.Basket.Infrastructure.Dto
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
