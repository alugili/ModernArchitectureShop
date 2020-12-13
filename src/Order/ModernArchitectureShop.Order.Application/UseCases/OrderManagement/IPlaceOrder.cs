using System;
using System.Collections.Generic;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Application.UseCases.OrderManagement
{
    public interface IPlaceOrder
    {
        public string Username { get; }
        public ICollection<Item> Items { get; }
        public DateTimeOffset CreationDate { get; }
    }
}
