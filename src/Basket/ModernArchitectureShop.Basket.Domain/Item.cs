using System;

namespace ModernArchitectureShop.Basket.Domain
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Price { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
    }
}
