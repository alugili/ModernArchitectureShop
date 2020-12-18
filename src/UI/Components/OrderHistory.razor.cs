using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModernArchitectureShop.ShopUI.Services;

namespace ModernArchitectureShop.ShopUI.Components
{
    public partial class OrderHistory
    {
        private string _errorMessage = string.Empty;
        private string _username = "Anonymous User";

        [Inject]
        private OrderHttpClientService OrderHttpClientService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _errorMessage = string.Empty;

            var state = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
            _username = state.User.Claims
                .Where(c => c.Type.Equals("name"))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;

            await CompletedOrders();
            await base.OnInitializedAsync();
        }

        private async ValueTask CompletedOrders()
        {
            var url = $"api/orders/completedorders?Username={_username}";
            var response = await this.OrderHttpClientService.GetAsync(url);

            if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
               
            }
            else
            {
                _errorMessage = $"Error: {response.Error}";
            }
        }
    }
}
