using System;

namespace ModernArchitectureShop.ShopUI.Models
{
    public class ItemModel
    {
        public Guid ItemId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
