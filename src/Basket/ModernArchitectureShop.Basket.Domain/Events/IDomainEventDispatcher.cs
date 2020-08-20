using System.Threading.Tasks;

namespace ModernArchitectureShop.Basket.Domain.Events
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent @event);
    }
}
