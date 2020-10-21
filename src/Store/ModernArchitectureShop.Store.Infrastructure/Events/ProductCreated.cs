using System;

namespace ModernArchitectureShop.Store.Infrastructure.Events
{
    public class ProductCreated : IDomainEvent
    {
        public DateTime CreatedOn => DateTime.UtcNow;

        public Guid ProductId { get; set; }

        public string ProductCode { get; set; } = string.Empty;

        public DateTime CreatedAt { get; } = DateTime.MinValue;
    }
}
