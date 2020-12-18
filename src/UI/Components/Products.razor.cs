#nullable disable
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModernArchitectureShop.ShopUI.DaprClients;
using ModernArchitectureShop.ShopUI.Models;
using ModernArchitectureShop.ShopUI.Services;

namespace ModernArchitectureShop.ShopUI.Components
{
    public partial class Products
    {
        [Parameter]
        public int Page { get; set; }
        private const int PageSize = 9;

        private string _errorMessage = string.Empty;
        private string _username = "Anonymous User";
        private ProductsModel _productsModel = new ProductsModel();
        private string _queryFilter = string.Empty;

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ProductHttpClientService ProductHttpClientService { get; set; }

        [Inject]
        private ProductsDaprClient ProductsDaprClient { get; set; }

        [Inject]
        private BasketHttpClientService BasketHttpClientService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Page = 1;

            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            _username =
              state.User.Claims
                .Where(c => c.Type.Equals("name"))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;

            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            // Do it with Dapr
            //try
            //{
            //  ProductsDaprClient.GetProductsResponse products =
            //    await ProductsDaprClient.GetProductsAsync("api/products",
            //      new ProductsDaprClient.GetProductsCommand { Page = Page, PageSize = _pageSize },
            //      new CancellationToken());

            //  _productsModel = new ProductsModel { Products = products.Products.ToList(), TotalOfProducts = products.TotalOfProducts };
            //}
            //catch (Exception e)
            //{
            //  // Todo just for Developers!
            //  _errorMessage = $"Error: {e.Message}";
            //  _productsModel = new ProductsModel();;
            //}

            // Do it with HTTP classic
            var response = await ProductHttpClientService.GetAsync(ProcessUrl());

            if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                _productsModel = JsonSerializer
                                               .Deserialize<ProductsModel>(response.Content,
                                                                          new JsonSerializerOptions
                                                                          {
                                                                              PropertyNameCaseInsensitive = true
                                                                          });
            }
            else
            {
                _errorMessage = $"Error: {response.Error}";
                _productsModel = new ProductsModel();
            }
        }

        async Task AddProductToBasketAsync(ItemModel itemModel)
        {
            var response = await BasketHttpClientService.AddAsync($"api/item/", itemModel);

            if (response.StatusCode != (int)System.Net.HttpStatusCode.OK)
            {
                _errorMessage = $"Error: {response.Error}";
                _productsModel = new ProductsModel();
            }
        }

        async Task Search(ChangeEventArgs e)
        {
            await Task.Run(async () =>
            {
                Page = 1;

                // Do it with Dapr
                //try
                //  {
                //    var products =
                //      await ProductsDaprClient.SearchProductsAsync("api/products/search-products",
                //        new ProductsDaprClient.SearchProductsCommand { Filter = e.Value.ToString(), PageIndex = Page, PageSize = _pageSize },
                //        new CancellationToken());

                //    _productsModel = new ProductsModel { Products = products.Products.ToList(), TotalOfProducts = products.TotalOfProducts };
                //  }
                //  catch (Exception e)
                //  {
                //  // Todo just for Developers!
                //  _errorMessage = $"Error: {e.Message}";
                //    _productsModel = new ProductsModel(); ;
                //  }

                _queryFilter = e.Value?.ToString() ?? string.Empty;
                // Do it with HTTP classic
                var response = await ProductHttpClientService.GetAsync(ProcessUrl());

                if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
                {
                    _productsModel = JsonSerializer.Deserialize<ProductsModel>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    _errorMessage = $"Error: {response.Error}";
                    _productsModel = new ProductsModel();
                }
            });
        }

        private string ProcessUrl()
        {
            if (!(string.IsNullOrEmpty(_queryFilter) || string.IsNullOrWhiteSpace(_queryFilter)))
                return $"api/products/search-products?Filter={_queryFilter}&PageIndex={Page}&PageSize={PageSize}";

            var url = $"api/products?PageIndex={Page}&PageSize={PageSize}";
            return url;
        }
    }
}
