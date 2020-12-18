using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModernArchitectureShop.ShopUI.Models;
using ModernArchitectureShop.ShopUI.Services;

namespace ModernArchitectureShop.ShopUI.Components
{
    public partial class Order
    {
        private string _errorMessage =string.Empty;
        private string _username =string.Empty;
        private ItemsModel _itemsModel = new ItemsModel();

        [Inject]
        private BasketHttpClientService? BasketsService { get; set; }

        [Inject]
        private OrderHttpClientService? OrderService { get; set; }

        [Inject]
        private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _errorMessage = string.Empty;

            var state = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
            _username = state.User.Claims
                .Where(c => c.Type.Equals("name"))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;

            await BasketItems();
            await base.OnInitializedAsync();
        }

        private async ValueTask BasketItems()
        {
            var url = $"api/items?Username={_username}";
            var response = await this.BasketsService!.GetAsync(url);

            if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                _itemsModel = JsonSerializer
                    .Deserialize<ItemsModel>(response.Content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
            else
            {
                _errorMessage = $"Error: {response.Error}";
                _itemsModel = new ItemsModel();
            }
        }

        private async ValueTask RemoveProductFromBasketAsync(ItemModel itemModel)
        {
            var id = itemModel.ItemId;

            _itemsModel!.Items.Remove(itemModel);

            var response = await BasketsService!.RemoveAsync($"api/item/{id}");

            if (response.StatusCode != (int)System.Net.HttpStatusCode.OK)
            {
                _errorMessage = $"Error: {response.Error}";
                _itemsModel = new ItemsModel();
            }
        }

        private async ValueTask BuyItemsAsync()
        {
            await OrderService!.PlaceOrderAsync($"api/order/", _username!, _itemsModel!);
        }
    }
}
