using System;

namespace ModernArchitectureShop.Basket.Infrastructure.Dto
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string Username { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public StoreDto Store { get; set; } = new StoreDto();
    }
}
