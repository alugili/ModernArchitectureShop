using System;

namespace ModernArchitectureShop.Order.Domain
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double? Price { get; set; }
        public int Count { get; set; }
    }
}
