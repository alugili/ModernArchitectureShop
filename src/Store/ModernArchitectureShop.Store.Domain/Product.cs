using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernArchitectureShop.Store.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } 
        public string Name { get; set; } 
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }

        public Guid StoreId { get; set; }
        public Store Store { get; set; }
    }
}
