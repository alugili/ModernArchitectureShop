using System;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dto
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Price { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public StoreDto Store { get; set; }
    }
}
