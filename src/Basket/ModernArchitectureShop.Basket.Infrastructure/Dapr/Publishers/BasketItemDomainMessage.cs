using MediatR;
using ModernArchitectureShop.Basket.Domain.Events;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers
{
    public class BasketItemDomainMessage : INotification
    {
        public IDomainEvent BasketItemCreatedNotification { get; set; } = null!;
    }
}
