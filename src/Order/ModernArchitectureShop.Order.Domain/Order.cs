using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Order.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public ICollection<Item>? Items { get; set; }
        public string Username { get; set; } = string.Empty;
        public Status Status { get; set; }
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;
    }
}
