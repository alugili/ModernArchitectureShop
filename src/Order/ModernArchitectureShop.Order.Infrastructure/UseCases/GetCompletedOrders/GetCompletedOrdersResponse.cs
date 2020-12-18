using System.Collections.Generic;
using ModernArchitectureShop.Order.Infrastructure.Dto;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetCompletedOrders
{
    public class GetCompletedOrdersResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; } = new OrderDto[0];
    }
}
