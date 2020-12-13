using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModernArchitectureShop.ShopUI.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ModernArchitectureShop.ShopUI.Services
{
    public class OrderService
    {
        record TempDataHolder(string Username, ICollection<ItemModel> Items, DateTimeOffset CreationDate);

        private readonly HttpClient _orderHttpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(HttpClient basketHttpClient, IHttpContextAccessor httpContextAccessor)
        {
            _orderHttpClient = basketHttpClient ?? throw new ArgumentNullException(nameof(basketHttpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<ServiceResult<string>> PlaceOrderAsync(string url, string username, ItemsModel itemsModes)
        {
            await TokenProvider.AttachAccessTokenToHeader(_orderHttpClient, _httpContextAccessor);

            HttpResponseMessage response;
            try
            {
                var items = new TempDataHolder(username, itemsModes.Items, DateTimeOffset.UtcNow);

                var json = JsonSerializer.Serialize(items);

                //Needed to setup the body of the request
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                response = await _orderHttpClient.PostAsync(url, data);
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
                Content = null!,
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };

        }

        public async Task<ServiceResult<string>> RemoveOrderAsync(string url)
        {
            await TokenProvider.AttachAccessTokenToHeader(_orderHttpClient, _httpContextAccessor);

            HttpResponseMessage response;
            try
            {
                response = await _orderHttpClient.DeleteAsync(url);
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
                Content = null!,
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };

        }
    }
}
