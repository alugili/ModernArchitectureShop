using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ModernArchitectureShop.BlazorUI
{
    public class LoginModel : PageModel
    {
        public async Task OnGet()
        {
            if (HttpContext.User.Identity != null && !HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.ChallengeAsync(new AuthenticationProperties { RedirectUri = "/secure" });
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}
