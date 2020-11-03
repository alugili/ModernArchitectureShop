using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModernArchitectureShop.Store.Domain
{
    public class Store
    {
        public Guid StoreId { get; set; }
        public string? Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new Collection<Address>();
        public ICollection<Product> Products { get; set; } = new Collection<Product>();
    }
}
