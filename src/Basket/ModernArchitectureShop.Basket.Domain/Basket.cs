using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModernArchitectureShop.Basket.Domain
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public string Username { get; set; } = string.Empty;
        public ICollection<Item> Items { get; set; } = new Collection<Item>();
        public State State { get; set; }
    }
}
