using MediatR;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers.Messages
{
    public class ItemUpdatedMessage : Item, INotification
    {
    }
}
