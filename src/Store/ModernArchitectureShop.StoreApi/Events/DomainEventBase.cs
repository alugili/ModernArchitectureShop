using System;
using System.Collections.Generic;
using MediatR;

namespace ModernArchitectureShop.StoreApi.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime CreatedAt { get; }
    }

    public interface IDomainEventContext
    {
        IEnumerable<DomainEventBase> GetDomainEvents();
    }

    public abstract class DomainEventBase : IDomainEvent
    {
        public DateTime CreatedAt { get; }
    }
}
