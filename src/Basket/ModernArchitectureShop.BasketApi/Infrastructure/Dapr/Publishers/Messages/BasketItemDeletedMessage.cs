using System;
using MediatR;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers.Messages
{
    public class BasketItemDeletedMessage : INotification
    {
        public  Guid ItemId { get; set; }
    }
}
