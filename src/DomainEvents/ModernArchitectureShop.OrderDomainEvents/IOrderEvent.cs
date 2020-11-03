using System;

namespace ModernArchitectureShop.OrderDomainEvents
{
    public interface IOrderEvent
    {
        public Order.Domain.Order Order { get; set; }
        public DateTimeOffset CreationDate { get; }
    }

}
