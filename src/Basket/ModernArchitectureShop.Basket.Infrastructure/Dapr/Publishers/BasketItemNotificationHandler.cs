using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers.Messages;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers
{
    public class BasketItemNotificationHandler
        : INotificationHandler<BasketItemCreatedMessage>
        , INotificationHandler<BasketItemUpdatedMessage>
        , INotificationHandler<BasketItemDeletedMessage>
    {
        private readonly ILogger<BasketItemNotificationHandler> _logger;
        private readonly DaprClient _daprClient;

        public BasketItemNotificationHandler(ILogger<BasketItemNotificationHandler> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        public async Task Handle(BasketItemCreatedMessage basketItemCreatedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(basketItemCreatedMessage)}: {JsonSerializer.Serialize(basketItemCreatedMessage)}");
            await _daprClient.PublishEventAsync("messagebus","ProductCreated", basketItemCreatedMessage, cancellationToken);
        }

        public async Task Handle(BasketItemUpdatedMessage basketItemUpdatedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(basketItemUpdatedMessage)}: {JsonSerializer.Serialize(basketItemUpdatedMessage)}");
            await _daprClient.PublishEventAsync("messagebus","ProductUpdated", basketItemUpdatedMessage, cancellationToken);
        }

        public async Task Handle(BasketItemDeletedMessage basketItemDeletedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(basketItemDeletedMessage)}: {JsonSerializer.Serialize(basketItemDeletedMessage)}");
            await _daprClient.PublishEventAsync("messagebus","ProductDeleted", basketItemDeletedMessage, cancellationToken);
        }
    }
}
