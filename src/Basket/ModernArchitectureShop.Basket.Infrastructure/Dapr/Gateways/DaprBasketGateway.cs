using Dapr.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ModernArchitectureShop.Basket.Infrastructure.Dapr.Gateways
{
    public class DaprBasketGateway
    {
        private string? _basketAppId;

        private readonly DaprClient _daprClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DaprBasketGateway> _logger;

        public DaprBasketGateway(ILogger<DaprBasketGateway> logger, DaprClient daprClient, IConfiguration configuration)
        {
            _logger = logger;
            _daprClient = daprClient;
            _configuration = configuration;
        }
    }
}
