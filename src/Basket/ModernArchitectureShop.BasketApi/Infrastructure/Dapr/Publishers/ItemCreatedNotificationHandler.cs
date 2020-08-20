using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers.Messages;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers
{
    public class ItemCreatedNotificationHandler
        : INotificationHandler<ItemCreatedMessage>
        , INotificationHandler<ItemUpdatedMessage>
        , INotificationHandler<ItemDeletedMessage>
    {
        private readonly ILogger<ItemCreatedNotificationHandler> _logger;
        private readonly DaprClient _daprClient;

        public ItemCreatedNotificationHandler(ILogger<ItemCreatedNotificationHandler> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        public async Task Handle(ItemCreatedMessage itemCreatedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(itemCreatedMessage)}: {JsonSerializer.Serialize(itemCreatedMessage)}");
            await _daprClient.PublishEventAsync("ProductCreated", itemCreatedMessage, cancellationToken);
        }

        public async Task Handle(ItemUpdatedMessage itemUpdatedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(itemUpdatedMessage)}: {JsonSerializer.Serialize(itemUpdatedMessage)}");
            await _daprClient.PublishEventAsync("ProductUpdated", itemUpdatedMessage, cancellationToken);
        }

        public async Task Handle(ItemDeletedMessage itemDeletedMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Publishing the message {nameof(itemDeletedMessage)}: {JsonSerializer.Serialize(itemDeletedMessage)}");
            await _daprClient.PublishEventAsync("ProductDeleted", itemDeletedMessage, cancellationToken);
        }
    }
}
