using System;

namespace ModernArchitectureShop.Store.Application.UseCases.AddOrUpdateProductStore
{
    public interface IAddOrdUpdateProductStore
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
