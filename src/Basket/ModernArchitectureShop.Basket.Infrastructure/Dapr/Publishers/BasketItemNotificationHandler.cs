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
        : INotificationHandler<ItemCreatedMessage>
        , INotificationHandler<ItemUpdatedMessage>
        , INotificationHandler<BasketItemDeletedMessage>
    {
        private readonly ILogger<BasketItemNotificationHandler> _logger;
        private readonly DaprClient _daprClient;

        public BasketItemNotificationHandler(ILogger<BasketItemNotificationHandler> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        public async Task Handle(ItemCreatedMessage itemCreatedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(itemCreatedMessage)}: {JsonSerializer.Serialize(itemCreatedMessage)}");
            await _daprClient.PublishEventAsync("messagebus","ProductCreated", itemCreatedMessage, cancellationToken);
        }

        public async Task Handle(ItemUpdatedMessage itemUpdatedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(itemUpdatedMessage)}: {JsonSerializer.Serialize(itemUpdatedMessage)}");
            await _daprClient.PublishEventAsync("messagebus","ProductUpdated", itemUpdatedMessage, cancellationToken);
        }

        public async Task Handle(BasketItemDeletedMessage basketItemDeletedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(basketItemDeletedMessage)}: {JsonSerializer.Serialize(basketItemDeletedMessage)}");
            await _daprClient.PublishEventAsync("messagebus","ProductDeleted", basketItemDeletedMessage, cancellationToken);
        }
    }
}
