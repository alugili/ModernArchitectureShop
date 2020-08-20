using System;

namespace ModernArchitectureShop.StoreApi.Events
{
    public class ProductCreated : IDomainEvent
    {
        public DateTime CreatedOn => DateTime.UtcNow;

        public Guid ProductId { get; set; }

        public string ProductCode { get; set; }

        public DateTime CreatedAt { get; }
    }
}
