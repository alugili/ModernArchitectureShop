using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernArchitectureShop.BlazorUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernArchitectureShop.BlazorUI.Services
{
    public class BasketProductService
    {
        private readonly HttpClient _basketHttpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketProductService(HttpClient basketHttpClient, IHttpContextAccessor httpContextAccessor)
        {
            _basketHttpClient = basketHttpClient ?? throw new ArgumentNullException(nameof(basketHttpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task AttachAccessTokenToHeader()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                var auth = _basketHttpClient.DefaultRequestHeaders.Authorization?.Parameter;
                if (auth == null)
                    _basketHttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
        }

        public async Task<ServiceResult<string>> AddItemAsync(string url, ItemModel itemModel)
        {
            await AttachAccessTokenToHeader();

            HttpResponseMessage response;
            try
            {
                var json = JsonConvert.SerializeObject(itemModel);

                //Needed to setup the body of the request
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                response = await _basketHttpClient.PostAsync(url, data);
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

            return new ServiceResult<string>
            {
                Content = null,
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };

        }

        public async Task<ServiceResult<string>> RemoveItemAsync(string url)
        {
            await AttachAccessTokenToHeader();

            HttpResponseMessage response;
            try
            {
                response = await _basketHttpClient.DeleteAsync(url);
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

            return new ServiceResult<string>
            {
                Content = null,
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };

        }
        public async Task<ServiceResult<string>> GetItemsAsync(string url)
        {
            await AttachAccessTokenToHeader();

            HttpResponseMessage response;
            try
            {
                response = await _basketHttpClient.GetAsync(url);
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
