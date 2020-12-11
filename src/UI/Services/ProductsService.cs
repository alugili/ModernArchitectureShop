using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModernArchitectureShop.ShopUI.Services
{
    public class ProductsService
    {
        private readonly HttpClient _storeHttpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductsService(HttpClient storeHttpClient, IHttpContextAccessor httpContextAccessor)
        {
            _storeHttpClient = storeHttpClient ?? throw new ArgumentNullException(nameof(storeHttpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        }

        public async Task<ServiceResult<string>> SearchProductsAsync(string url)
        {
            await TokenProvider.AttachAccessTokenToHeader(_storeHttpClient, _httpContextAccessor);

            HttpResponseMessage response;
            try
            {
                response = await _storeHttpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return new ServiceResult<string>
                {
                    Content = null!,
                    StatusCode = 500, // Server Error!
                    Error = e.Message
                };
            }

            return new ServiceResult<string>
            {
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };

        }

        public async Task<ServiceResult<string>> GetProductsAsync(string url)
        {
            await TokenProvider.AttachAccessTokenToHeader(_storeHttpClient, _httpContextAccessor);

            HttpResponseMessage response;
            try
            {
                response = await _storeHttpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return new ServiceResult<string>
                {
                    Content = null!,
                    StatusCode = 500, // Server Error!
                    Error = e.Message
                };
            }

            return new ServiceResult<string>
            {
                Content =  await response.Content.ReadAsStringAsync(),
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };
        }
    }
}
