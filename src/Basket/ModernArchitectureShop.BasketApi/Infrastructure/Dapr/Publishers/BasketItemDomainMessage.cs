using MediatR;
using ModernArchitectureShop.Basket.Domain.Events;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers
{
    public class BasketItemDomainMessage : INotification
    {
        public IDomainEvent BasketItemCreatedNotification { get; set; }
    }
}
