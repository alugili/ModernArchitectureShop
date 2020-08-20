using System;
using MediatR;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers.Messages
{
    public class ItemDeletedMessage : INotification
    {
        public  Guid ItemId { get; set; }
    }
}
