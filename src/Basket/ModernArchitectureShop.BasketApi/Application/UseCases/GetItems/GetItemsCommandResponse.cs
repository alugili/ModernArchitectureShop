using System.Collections.Generic;
using ModernArchitectureShop.BasketApi.Infrastructure.Dto;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.GetProducts
{
    public class GetItemsCommandResponse
    {
        public IEnumerable<ItemDto> Items { get; set; }
        public int TotalOfItems { get; set; }
        public int Availability { get; set; }
    }
}
