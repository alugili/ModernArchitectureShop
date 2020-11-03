using System;

namespace ModernArchitectureShop.Basket.Domain
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string Username { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
