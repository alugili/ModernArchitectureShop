using System;
using System.Collections.Generic;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class OrderDto
    {
        public OrderDto(Guid orderId, Guid storeId, string username, State state, ICollection<Item>? items)
        {
            OrderId = orderId;
            StoreId = storeId;
            Items = items;
            Username = username;
            State = state;
        }

        public Guid OrderId { get; }
        public Guid StoreId { get; }
        public string Username { get; }
        public State State { get; }
        public DateTimeOffset CreationDate { get; }
        public ICollection<Item>? Items { get; }

    }
}
