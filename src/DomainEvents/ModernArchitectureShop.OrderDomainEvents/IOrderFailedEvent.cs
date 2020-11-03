using System;

namespace ModernArchitectureShop.DomainEvents
{
    public interface IOrderFailedEvent
    {
        public Order.Domain.Order Order { get; set; }
        public DateTimeOffset CreationDate { get; }
    }
}
