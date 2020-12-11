using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ModernArchitectureShop.ShopUI.Services
{
    public class IdentityService
    {
        private readonly AuthenticationStateProvider _authState;

        public IdentityService(AuthenticationStateProvider authState)
        {
            _authState = authState;
        }

        // Get user claims json from the API get method 
        public async Task<string> GetApiUserClaimsJson()
        {
            var authState = await _authState.GetAuthenticationStateAsync();

            var jsonIdentities = string.Empty;
            foreach (var identity in authState.User.Identities)
            {
                var id = JsonSerializer.Serialize(identity, new JsonSerializerOptions
                {
                    MaxDepth = 0,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true
                });

                jsonIdentities += id;
            }

            return jsonIdentities;
        }

        public async Task<string> GetAppUserClaimsJson()
        {
            var authState = await _authState.GetAuthenticationStateAsync();

            var jsonIdentities = string.Empty;
            foreach (var identity in authState.User.Claims)
            {
                var id = JsonSerializer.Serialize(identity, new JsonSerializerOptions
                {
                    MaxDepth = 0,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true
                });

                jsonIdentities += id;
            }

            return jsonIdentities;
        }
    }
}
