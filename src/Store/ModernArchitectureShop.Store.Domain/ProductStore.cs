using System;

namespace ModernArchitectureShop.Store.Domain
{
    public class ProductStore
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Store Store { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
