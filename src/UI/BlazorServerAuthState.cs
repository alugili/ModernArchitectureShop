// Copyright: https://mcguirev10.com/2019/12/15/blazor-authentication-with-openid-connect.html

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.Extensions.Logging;

namespace ModernArchitectureShop.BlazorUI
{
    public class BlazorServerAuthState : RevalidatingServerAuthenticationStateProvider
    {
        private readonly BlazorServerAuthStateCache Cache;

        public BlazorServerAuthState(ILoggerFactory loggerFactory, BlazorServerAuthStateCache cache)
            : base(loggerFactory)
        {
            Cache = cache;
        }

        protected override TimeSpan RevalidationInterval
            => TimeSpan.FromSeconds(10); // TODO read from config

        protected override Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            var sid =
                authenticationState.User.Claims
                .Where(c => c.Type.Equals("sid"))
                .Select(c => c.Value)
                .FirstOrDefault();

            var name =
                authenticationState.User.Claims
                .Where(c => c.Type.Equals("name"))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;
            System.Diagnostics.Debug.WriteLine($"\nValidate: {name} / {sid}");

            if (sid != null && Cache.HasSubjectId(sid))
            {
                var data = Cache.Get(sid);

                System.Diagnostics.Debug.WriteLine($"NowUtc: {DateTimeOffset.UtcNow.ToString("o")}");
                System.Diagnostics.Debug.WriteLine($"ExpUtc: {data.Expiration.ToString("o")}");

                if (DateTimeOffset.UtcNow >= data.Expiration)
                {
                    System.Diagnostics.Debug.WriteLine($"*** EXPIRED ***");
                    Cache.Remove(sid);
                    return Task.FromResult(false);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"(not in cache)");
            }

            return Task.FromResult(true);
        }
    }
}
