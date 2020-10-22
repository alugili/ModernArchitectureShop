using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.BlazorUI.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public IEnumerable<ProductStoreModel> ProductStores { get; set; } = new ProductStoreModel[0];
    }
}

