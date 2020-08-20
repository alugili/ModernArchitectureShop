using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModernArchitectureShop.BlazorUI.Services
{
    public class IdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        // Get user claims json from the API get method 
        public async Task<string> GetAPIUserClaimsJson()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                var auth = _httpClient.DefaultRequestHeaders.Authorization?.Parameter;
                if (auth == null)
                    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync($"identity");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }

            var rawJson = await response.Content.ReadAsStringAsync();
            var parsedJson = JToken.Parse(rawJson);
            return parsedJson.ToString(Formatting.Indented);

        }

        /// <summary>
        /// Gets user claims from the current httpcontext
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAPPUserClaimsJson()
        {
            try
            {
                var claimsList = _httpContextAccessor.HttpContext.User.Claims;

                var rawList = (from c in claimsList select new { c.Type, c.Value });
                var json = JsonConvert.SerializeObject(rawList, Formatting.Indented);

                return json;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
