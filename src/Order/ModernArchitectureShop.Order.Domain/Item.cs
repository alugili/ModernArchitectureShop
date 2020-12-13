using System;

namespace ModernArchitectureShop.Order.Domain
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
