using System;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.AddOrUpdateProductStore
{
    public class AddOrUpdateProductStoreResponse
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
