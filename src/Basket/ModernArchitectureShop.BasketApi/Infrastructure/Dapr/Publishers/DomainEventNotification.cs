using MediatR;
using ModernArchitectureShop.Basket.Domain.Events;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers
{
    public class DomainEventNotification : INotification
    {
        public IDomainEvent DomainEvent { get; set; }
    }
}
