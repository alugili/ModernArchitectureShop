using System.Collections.Generic;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProducts
{
    public class GetProductsCommandResponse
    {
        public int TotalOfProducts { get; set; }
        public IEnumerable<ProductDto> Products { get; set; } = new ProductDto[0];
    }
}
