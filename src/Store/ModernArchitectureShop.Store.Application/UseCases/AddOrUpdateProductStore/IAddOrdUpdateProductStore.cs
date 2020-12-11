using System;

namespace ModernArchitectureShop.Store.Application.UseCases.AddOrUpdateProductStore
{
    public interface IAddOrdUpdateProductStore
    {
        public Guid ProductId { get; }
        public Guid StoreId { get; }
        public int Quantity { get; }
        public bool CanPurchase { get; }
    }
}
