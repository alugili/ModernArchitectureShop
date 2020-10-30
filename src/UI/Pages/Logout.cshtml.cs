using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ModernArchitectureShop.BlazorUI
{
    public class LogoutModel : PageModel
    {
        public async Task OnGet()
        {
            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync("Cookies");
                await HttpContext.SignOutAsync("oidc");
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}
