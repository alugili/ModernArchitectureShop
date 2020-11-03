using System;

namespace ModernArchitectureShop.OrderDomainEvents
{
    public interface UpdateProductAvailabilityEvent
    {
        public Order.Domain.Order Order { get; set; }
        public DateTimeOffset CreationDate { get; }

    }
}
