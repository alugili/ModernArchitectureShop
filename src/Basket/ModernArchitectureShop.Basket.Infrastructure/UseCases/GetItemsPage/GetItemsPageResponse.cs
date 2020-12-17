using System.Collections.Generic;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItemsPage
{
    public class GetItemsPageResponse
    {
        public IEnumerable<ItemDto>? Items { get; set; } = new ItemDto[0];
        public int TotalOfItems { get; set; }
        public int Availability { get; set; }
        public double TotalPrice { get; set; }
    }
}
