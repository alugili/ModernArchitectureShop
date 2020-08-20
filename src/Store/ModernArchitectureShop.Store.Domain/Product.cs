using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Store.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<ProductStore> ProductStores { get; set; }
    }
}
