using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModernArchitectureShop.ShopUI.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ModernArchitectureShop.ShopUI.Services
{
    public class OrderHttpClientService : HttpClientServiceBase
    {
        record TempDataHolder(string Username, ICollection<ItemModel> Items, DateTimeOffset CreationDate);

        public OrderHttpClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<HttpClientServiceResult<string>> PlaceOrderAsync(string url, string username, ItemsModel itemsModes)
        {
            await TokenProvider.AttachAccessTokenToHeader(HttpClient, HttpContextAccessor);

            HttpResponseMessage response;
            try
            {
                var items = new TempDataHolder(username, itemsModes.Items, DateTimeOffset.UtcNow);

                var json = JsonSerializer.Serialize(items);

                //Needed to setup the body of the request
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                response = await HttpClient.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return new HttpClientServiceResult<string>
                {
                    Content = null!,
                    StatusCode = 500, // Server Error!
                    Error = e.Message
                };
            }

            return new HttpClientServiceResult<string>
            {
                Content = null!,
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };

        }
    }
}
