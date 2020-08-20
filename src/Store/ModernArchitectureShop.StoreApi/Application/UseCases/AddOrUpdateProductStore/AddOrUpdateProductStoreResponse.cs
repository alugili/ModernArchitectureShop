using System;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.AddOrUpdateProductStore
{
    public class AddOrUpdateProductStoreResponse
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public string Code { get; set; }
        public string StoreName { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
