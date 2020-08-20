using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModernArchitectureShop.BlazorUI.Services
{
    public class ProductService
    {
        private readonly HttpClient _storeHttpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(HttpClient storeHttpClient, IHttpContextAccessor httpContextAccessor)
        {
            _storeHttpClient = storeHttpClient ?? throw new ArgumentNullException(nameof(storeHttpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        }

        public async Task AttachAccessTokenToHeader()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                var auth = _storeHttpClient.DefaultRequestHeaders.Authorization?.Parameter;
                if (auth == null)
                    _storeHttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
        }

        public async Task<ServiceResult<string>> GetProductsAsync(string url)
        {
            await AttachAccessTokenToHeader();

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
                    Content = null,
                    StatusCode = 500, // Server Error!
                    Error = e.Message
                };
            }

            var rawJson = await response.Content.ReadAsStringAsync();
            var parsedJson = JToken.Parse(rawJson);

            return new ServiceResult<string>
            {
                Content = parsedJson.ToString(Formatting.Indented),
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };
        }
    }
}
