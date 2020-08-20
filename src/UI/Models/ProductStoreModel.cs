using System;

namespace ModernArchitectureShop.BlazorUI.Models
{
    public class ProductStoreModel
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
