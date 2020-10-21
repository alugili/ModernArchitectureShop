using System;
using MediatR;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers.Messages
{
    public class BasketItemDeletedMessage : INotification
    {
        public  Guid ItemId { get; set; }
    }
}
