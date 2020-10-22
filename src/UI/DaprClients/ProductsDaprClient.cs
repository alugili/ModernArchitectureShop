using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using Dapr.Client.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using ModernArchitectureShop.BlazorUI.Models;
using ModernArchitectureShop.BlazorUI.Services;

namespace ModernArchitectureShop.BlazorUI.DaprClients
{

    /// <summary>
    /// This class is alternative for <see cref="ProductsService"/>.
    /// </summary>
    public class ProductsDaprClient
    {
        private readonly DaprClient _daprClient;

        public ProductsDaprClient(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task<GetProductsResponse> GetProductsAsync(
            string url,
            GetProductsCommand getProductsCommand,
            CancellationToken cancellationToken)
        {
            return await this._daprClient.
                      InvokeMethodAsync<GetProductsCommand, GetProductsResponse>
                      ("storeapi",
             url,
                      getProductsCommand,
                      new HTTPExtension { Verb = HTTPVerb.Get },
                      cancellationToken);
        }

        public async Task<GetProductsResponse> SearchProductsAsync(
            string url,
            SearchProductsCommand searchProductsCommand,
            CancellationToken cancellationToken)
        {
            return await this._daprClient.
                InvokeMethodAsync<SearchProductsCommand, GetProductsResponse>
                ("storeapi",
                    url,
                    searchProductsCommand,
                    new HTTPExtension { Verb = HTTPVerb.Get },
                    cancellationToken);
        }

        public class GetProductsCommand
        {
            public int PageIndex { get; set; } = 1;

            public int PageSize { get; set; } = 10;
        }

        public class GetProductsResponse
        {
            public int TotalOfProducts { get; set; }
            public IEnumerable<ProductModel> Products { get; set; } = new ProductModel[0];
        }

        public class SearchProductsCommand
        {
            public string Filter { get; set; } = string.Empty;

            public int PageIndex { get; set; } = 1;

            public int PageSize { get; set; } = 10;
        }

    }
}
