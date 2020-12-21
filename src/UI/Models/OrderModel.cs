using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.ShopUI.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int State { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public IEnumerable<ItemModel> Items { get; set; } = new ItemModel[0];
    }
}
