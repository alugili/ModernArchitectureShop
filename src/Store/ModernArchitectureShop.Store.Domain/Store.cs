using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Store.Domain
{
    public class Store
    {
        public Guid StoreId { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductStore> ProductStores { get; set; }
    }
}
