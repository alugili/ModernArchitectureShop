using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModernArchitectureShop.BlazorUI
{
    public class _HostAuthModel : PageModel
    {
        public readonly BlazorServerAuthStateCache Cache;

        public _HostAuthModel(BlazorServerAuthStateCache cache)
        {
            Cache = cache;
        }

        public async Task<IActionResult> OnGet()
        {
            System.Diagnostics.Debug.WriteLine($"\n_Host OnGet IsAuth? {User.Identity.IsAuthenticated}");

            if (User.Identity.IsAuthenticated)
            {
                var sid = User.Claims
                    .Where(c => c.Type.Equals("sid"))
                    .Select(c => c.Value)
                    .FirstOrDefault();

                System.Diagnostics.Debug.WriteLine($"sid: {sid}");

                if (sid != null && !Cache.HasSubjectId(sid))
                {
                    var authResult = await HttpContext.AuthenticateAsync("oidc");
                    var expiration = authResult.Properties.ExpiresUtc.Value;
                    var accessToken = await HttpContext.GetTokenAsync("access_token");
                    var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
                    Cache.Add(sid, expiration, accessToken, refreshToken);
                }
            }
            return Page();
        }

        public IActionResult OnGetLogin()
        {
            System.Diagnostics.Debug.WriteLine("\n_Host OnGetLogin");
            var authProps = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                RedirectUri = Url.Content("~/")
            };
            return Challenge(authProps, "oidc");
        }

        public async Task OnGetRegsiter()
        {
            System.Diagnostics.Debug.WriteLine("\n_Host OnGetRegsiter");
            var authProps = new AuthenticationProperties
            {
                RedirectUri = Url.Content("~/")
            };
        }

        public async Task OnGetLogout()
        {
            System.Diagnostics.Debug.WriteLine("\n_Host OnGetLogout");
            var authProps = new AuthenticationProperties
            {
                RedirectUri = Url.Content("~/")
            };
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc", authProps);
        }
    }
}
