using MediatR;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers.Messages
{
    public class BasketItemUpdatedMessage : Item, INotification
    {
    }
}
