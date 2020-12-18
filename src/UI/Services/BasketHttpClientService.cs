using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace ModernArchitectureShop.ShopUI.Services
{
    public class BasketHttpClientService : HttpClientServiceBase
    {

        public BasketHttpClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor)
        {
        }
    }
}
