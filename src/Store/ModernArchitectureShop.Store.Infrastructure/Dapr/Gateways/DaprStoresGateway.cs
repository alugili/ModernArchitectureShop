using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.Store.Infrastructure.UseCases.GetProducts;

namespace ModernArchitectureShop.Store.Infrastructure.Dapr.Gateways
{
    public class DaprStoresGateway
    {
        private readonly string StoreAppId;

        private readonly ILogger<DaprStoresGateway> _logger;
        private readonly DaprClient _daprClient;
        private readonly IConfiguration _configuration;

        public DaprStoresGateway(ILogger<DaprStoresGateway> logger, DaprClient daprClient, IConfiguration configuration)
        {
            _logger = logger;
            _daprClient = daprClient;
            _configuration = configuration;

            StoreAppId = configuration.GetValue<string>("IDENTITY_AUDIENCE");

            logger.LogInformation($"Begin to log dapr :{StoreAppId} ");
        }

        public async Task<GetProductsResponse> GetProducts
                    (GetProductsCommand command,
                     CancellationToken cancellationToken = default)
                                    => await _daprClient.InvokeMethodAsync<GetProductsCommand, GetProductsResponse>
                                         (StoreAppId,
                                        "api/dapr/products/",
                                          command,
                                          HttpInvocationOptions.UsingPost(),
                                          cancellationToken);

    }
}
