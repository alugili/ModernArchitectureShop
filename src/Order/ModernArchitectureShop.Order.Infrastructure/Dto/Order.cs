using System;
using System.Collections.Generic;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class OrderDto
    {
        public OrderDto(Guid orderId, Guid storeId, ICollection<Item>? items, string username, State state)
        {
            OrderId = orderId;
            StoreId = storeId;
            Items = items;
            Username = username;
            State = state;
        }

        public Guid OrderId { get; }
        public Guid StoreId { get; }
        public ICollection<Item>? Items { get; }
        public string Username { get; }
        public State State { get; }
        public DateTimeOffset CreationDate { get; } = DateTimeOffset.Now;
    }
}
