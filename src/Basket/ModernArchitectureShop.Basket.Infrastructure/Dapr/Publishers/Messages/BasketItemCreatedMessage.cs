using MediatR;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers.Messages
{
    public class BasketItemCreatedMessage : Item, INotification
    {
    }
}
