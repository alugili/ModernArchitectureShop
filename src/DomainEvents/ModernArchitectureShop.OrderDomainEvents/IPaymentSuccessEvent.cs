using System;

namespace ModernArchitectureShop.DomainEvents
{
    public interface IPaymentSuccessEvent
    {
        public Order.Domain.Order Order { get; set; }
        public DateTimeOffset CreationDate { get; }
    }
}
