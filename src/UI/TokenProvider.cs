using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ModernArchitectureShop.ShopUI
{
    public static class TokenProvider
    {
        public static async Task AttachAccessTokenToHeader([NotNull] HttpClient httpClient, [NotNull] IHttpContextAccessor httpContextAccessor)
        {
            Debug.Assert(httpContextAccessor.HttpContext != null, "httpContextAccessor.HttpContext != null");

            var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                var auth = httpClient.DefaultRequestHeaders.Authorization?.Parameter;
                if (auth == null)
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
        }
    }
}
