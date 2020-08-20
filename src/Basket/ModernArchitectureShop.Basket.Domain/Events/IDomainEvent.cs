using System;

namespace ModernArchitectureShop.Basket.Domain.Events
{
    public interface IDomainEvent 
    {
        DateTime CreatedAt { get; }
    }
}
