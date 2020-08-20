using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Gateways.UseCases.GetProducts
{
    public class GetProductsByIdsRequest
    {
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
