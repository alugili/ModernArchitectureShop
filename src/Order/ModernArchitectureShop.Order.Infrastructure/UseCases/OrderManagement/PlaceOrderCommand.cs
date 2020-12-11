using System;
using System.Collections.Generic;
using MediatR;
using ModernArchitectureShop.Order.Application.UseCases.OrderManagement;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement
{
    public class PlaceOrderCommand :  IRequest<bool>, IPlaceOrder
    {
        public PlaceOrderCommand(Guid orderId, Guid storeId, ICollection<Domain.Order>? items, string username, State state, DateTimeOffset creationDate)
        {
            OrderId = orderId;
            StoreId = storeId;
            Items = items;
            Username = username;
            State = state;
            CreationDate = creationDate;
        }

        public Guid OrderId { get; }
        public Guid StoreId { get; }
        public ICollection<Domain.Order>? Items { get; }
        public string Username { get; }
        public State State { get; }
        public DateTimeOffset CreationDate { get; }
    }
}
