using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernArchitectureShop.Basket.Domain
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        [ForeignKey("Basket")]
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
