using System;
using System.Collections.Generic;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Dto
{
    public class BasketDto
    {
        public BasketDto(Guid basketId, string username, ICollection<Item> items, State state)
        {
            BasketId = basketId;
            Username = username;
            Items = items;
            State = state;
        }

        public Guid BasketId { get; }
        public string Username { get; }
        public ICollection<Item> Items { get; }
        public State State { get; }
    }
}
