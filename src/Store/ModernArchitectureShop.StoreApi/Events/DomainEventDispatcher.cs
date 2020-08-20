using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ModernArchitectureShop.StoreApi.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DomainEventDispatcher> _logger;

        public DomainEventDispatcher(IMediator mediator, ILogger<DomainEventDispatcher> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Dispatch(IDomainEvent @event)
        {
            _logger.LogInformation($"Dispatching domain event: {@event.GetType().Name}");

            await _mediator.Publish(new DomainEventNotification
            {
                DomainEvent = @event
            });
        }

    }
}
