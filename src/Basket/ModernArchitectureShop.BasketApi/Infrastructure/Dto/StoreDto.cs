using System;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dto
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
