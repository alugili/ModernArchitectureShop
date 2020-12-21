using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using ModernArchitectureShop.ShopUI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;
using ModernArchitectureShop.ShopUI.Models;

namespace ModernArchitectureShop.ShopUI.Components
{
    public partial class OrderHistory
    {
        private string _errorMessage = string.Empty;
        private string _username = "Anonymous User";
        private OrdersModel OrdersModel { get; set; } = new OrdersModel();

        [Inject] private OrderHttpClientService OrderHttpClientService { get; set; }

        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

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
            var response = await OrderHttpClientService.GetAsync(url);

            if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                OrdersModel = JsonSerializer.Deserialize<OrdersModel>(response.Content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                _errorMessage = $"Error: {response.Error}";
                OrdersModel = new OrdersModel();
            }
        }
    }
}
