using System.Threading.Tasks;

namespace ModernArchitectureShop.Store.Infrastructure.Events

{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent @event);
    }
}
