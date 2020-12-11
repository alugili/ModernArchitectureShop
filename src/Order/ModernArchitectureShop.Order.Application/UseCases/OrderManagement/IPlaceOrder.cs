using System;
using System.Collections.Generic;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Application.UseCases.OrderManagement
{
    public interface IPlaceOrder
    {
        public Guid OrderId { get; }
        public Guid StoreId { get; }
        public ICollection<Domain.Order>? Items { get; }
        public string Username { get; }
        public State State { get; }
        public DateTimeOffset CreationDate { get; }
    }
}
