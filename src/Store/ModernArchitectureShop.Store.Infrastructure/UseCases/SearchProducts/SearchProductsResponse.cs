using System.Collections.Generic;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.SearchProducts
{
    public class SearchProductsResponse
    {
        public int TotalOfProducts { get; set; }
        public IEnumerable<ProductDto> Products { get; set; } = new ProductDto[0];
    }
}
