using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapr.Client;
using Dapr.Client.Http;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.BasketApi.Application.UseCases.GetProducts;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Gateways.UseCases.GetProducts;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Gateways
{
    public class DaprStoresGateway
    {
        private readonly string StoreAppId;

        private readonly DaprClient _daprClient;
        private readonly ILogger<DaprStoresGateway> _logger;


        private HTTPExtension HttpExtension => new HTTPExtension
        {
            Verb = HTTPVerb.Post
        };

        public DaprStoresGateway(ILogger<DaprStoresGateway> logger, DaprClient daprClient, IConfiguration configuration)
        {
            _logger = logger;
            _daprClient = daprClient;

            StoreAppId = configuration.GetValue<string>("STORE_API");

            _logger.LogInformation($"Begin to log dapr :StoreAppId ");
        }

        public async Task<GetItemsCommandResponse> GetProducts
                    (GetItemsCommand command,
                     CancellationToken cancellationToken = default)
                                    => await _daprClient.InvokeMethodAsync<GetItemsCommand, GetItemsCommandResponse>
                                         (StoreAppId,
                                        "api/product/",
                                          command,
                                          HttpExtension,
                                          cancellationToken);


        public async Task<GetProductsByIdsResponse>
                    GetProductsByIds(GetProductsByIdsRequest request,
                    CancellationToken cancellationToken = default)
                                    => await _daprClient.InvokeMethodAsync<GetProductsByIdsRequest, GetProductsByIdsResponse>
                                        (StoreAppId,
                                        "api/product/get-by-ids", request,
                                        HttpExtension,
                                        cancellationToken);
    }
}
