using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Order.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public string Username { get; set; } = string.Empty;
        public State State { get; set; }
        public DateTimeOffset CreationDate { get; set; } = new DateTimeOffset();
        public ICollection<Item>? Items { get; set; }
    }
}
