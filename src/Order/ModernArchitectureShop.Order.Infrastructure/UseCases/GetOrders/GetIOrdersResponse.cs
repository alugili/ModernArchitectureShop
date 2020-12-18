using System.Collections.Generic;
using ModernArchitectureShop.Order.Infrastructure.Dto;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetOrders
{
    public class GetOrdersResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; } = new OrderDto[0];
    }
}
