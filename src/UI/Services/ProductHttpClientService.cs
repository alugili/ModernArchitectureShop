using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace ModernArchitectureShop.ShopUI.Services
{
    public class ProductHttpClientService : HttpClientServiceBase
    {
        public ProductHttpClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor)
        {
        }
    }
}
