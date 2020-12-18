using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModernArchitectureShop.ShopUI.Models;

namespace ModernArchitectureShop.ShopUI.Services
{
    public abstract class HttpClientServiceBase : IHttpClientService
    {
        protected HttpClientServiceBase(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            HttpClient = httpClient;
            HttpContextAccessor = httpContextAccessor;
        }

        public HttpClient HttpClient { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }


        public async Task<HttpClientServiceResult<string>> AddAsync(string url, ItemModel itemModel)
        {
            await TokenProvider.AttachAccessTokenToHeader(HttpClient, HttpContextAccessor);

            HttpResponseMessage response;
            try
            {
                var json = JsonSerializer.Serialize(itemModel);

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

        public async Task<HttpClientServiceResult<string>> RemoveAsync(string url)
        {
            await TokenProvider.AttachAccessTokenToHeader(HttpClient, HttpContextAccessor);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.DeleteAsync(url);
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

        public async Task<HttpClientServiceResult<string>> GetAsync(string url)
        {
            await TokenProvider.AttachAccessTokenToHeader(HttpClient, HttpContextAccessor);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return new HttpClientServiceResult<string>
                {
                    Content = string.Empty!,
                    StatusCode = 500, // Server Error!
                    Error = e.Message
                };
            }

            return new HttpClientServiceResult<string>
            {
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = (int)response.StatusCode,
                Error = string.Empty
            };
        }
    }
}
