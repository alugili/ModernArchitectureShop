using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Store.Infrastructure.Dapr.Gateways.UseCases.GetProducts
{
    public class GetProductsByIdsRequest
    {
        public IEnumerable<Guid> ProductIds { get; set; } = new Guid[0];
    }
}
