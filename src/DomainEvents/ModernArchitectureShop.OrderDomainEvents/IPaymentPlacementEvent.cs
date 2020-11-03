using System;

namespace ModernArchitectureShop.DomainEvents
{
    public interface IPaymentPlacementEvent
    {
        public Order.Domain.Order Order { get; set; }
        public DateTimeOffset CreationDate { get; }
    }
}
