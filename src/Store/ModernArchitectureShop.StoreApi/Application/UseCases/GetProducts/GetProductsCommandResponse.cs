using System.Collections.Generic;
using ModernArchitectureShop.StoreApi.Infrastructure.Dto;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProducts
{
    public class GetProductsCommandResponse
    {
        public int TotalOfProducts { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
