#nullable disable
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModernArchitectureShop.ShopUI.Models;
using ModernArchitectureShop.ShopUI.Services;
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

        [Inject]
        private BasketHttpClientService BasketHttpClientService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _errorMessage = string.Empty;

            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            _username = state.User.Claims
                                          .Where(c => c.Type.Equals("name"))
                                          .Select(c => c.Value)
                                          .FirstOrDefault() ?? string.Empty;

            Page = 1;

            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await BasketItemsPage();
            await TotalPriceAsync();
        }

        private async ValueTask BasketItemsPage()
        {
            var url = $"api/items/getitemspage?PageIndex={Page}&PageSize={PageSize}&Username={_username}";
            var response = await BasketHttpClientService.GetAsync(url);

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

            var response = await BasketHttpClientService!.RemoveAsync($"api/item/{id}");

            if (response.StatusCode != (int)System.Net.HttpStatusCode.OK)
            {
                _errorMessage = $"Error: {response.Error}";
                _itemsModel = new ItemsModel();
            }

            await BasketItemsPage();
            await TotalPriceAsync();
        }

        private async ValueTask TotalPriceAsync()
        {
            var response = await BasketHttpClientService!.GetAsync($"api/items/totalprice?Username={_username}");

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
    }
}
