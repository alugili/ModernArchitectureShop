using System;
using MediatR;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModernArchitectureShop.Order.Application.UseCases.OrderManagement;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement
{
    public class PlaceOrderCommand : IRequest<bool>, IPlaceOrder
    {
        public string Username { get; set; } = string.Empty;
        public ICollection<Item> Items { get; set; } = new Collection<Item>();
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    }
}
