using MediatR;

namespace ModernArchitectureShop.StoreApi.Events
{
    /// <summary>
    /// This class contains the domain event which published from domain entity.
    /// We use DomainEventBus to handle and publish it back to the specific project,
    /// then it will handle and use some of popular event brokers like Redis/Kafka to handle it
    /// </summary>
    public class DomainEventNotification : INotification
    {
        public IDomainEvent DomainEvent { get; set; }
    }
}
