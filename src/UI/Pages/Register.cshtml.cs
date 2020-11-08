using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ModernArchitectureShop.ShopUI.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public RegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            // todo register async!
            var identityUrl = _configuration.GetValue<string>("IDENTITY_AUTHORITY");
            const string registerRoute = "/identity/account/register";
            Response.Redirect(identityUrl + registerRoute);
        }
    }
}
