using System.Threading.Tasks;

namespace ModernArchitectureShop.StoreApi.Events
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent @event);
    }
}
