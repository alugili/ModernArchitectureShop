using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModernArchitectureShop.ShopUI.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ModernArchitectureShop.ShopUI.Components
{
    public partial class Basket
    {
        [Parameter]
        public int Page { get; set; } = 1;
        private const int PageSize = 9;

        private string _errorMessage = string.Empty;
        private double _totalPrice;

        private ItemsModel _itemsModel = new ItemsModel();
        private string _username = "Anonymous User";

        protected override async Task OnInitializedAsync()
        {
            _errorMessage = string.Empty;

            var state = await AuthState.GetAuthenticationStateAsync();
            _username = state.User.Claims
                                          .Where(c => c.Type.Equals("name"))
                                          .Select(c => c.Value)
                                          .FirstOrDefault() ?? string.Empty;

            Page = 1;

            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await BasketItems();
            await TotalPriceAsync();
        }

        private async Task BasketItems()
        {
            var response = await BasketsService.GetBasketItemsAsync(ProcessUrl());

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

            _itemsModel.Items.Remove(itemModel);

            var response = await BasketsService.RemoveItemAsync($"api/item/{id}");

            if (response.StatusCode != (int)System.Net.HttpStatusCode.OK)
            {
                _errorMessage = $"Error: {response.Error}";
                _itemsModel = new ItemsModel();
            }

            await BasketItems();
            await TotalPriceAsync();
        }

        private async ValueTask TotalPriceAsync()
        {
            var response = await BasketsService.BasketTotalPrice($"api/items/totalprice?Username={_username}");

            if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                var priceTemplate = new { totalPrice = 0.0d };
                _totalPrice = JsonConvert.DeserializeAnonymousType(response.Content, priceTemplate).totalPrice;
            }
            else
            {
                _errorMessage = $"Error: {response.Error}";
                _itemsModel = new ItemsModel();
            }
        }

        private string ProcessUrl()
        {
            var url = $"api/items?PageIndex={Page}&PageSize={PageSize}&Username={_username}";
            return url;
        }

        private async Task BuyItemsAsync()
        {
            var response = await OrderService.PlaceOrderAsync($"api/order/", _username, _itemsModel);
        }
    }
}
