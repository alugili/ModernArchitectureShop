using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace ModernArchitectureShop.ShopUI.Services
{
    public interface IHttpClientService
    {

        HttpClient HttpClient { get; }
        IHttpContextAccessor HttpContextAccessor { get; }
    }
}
