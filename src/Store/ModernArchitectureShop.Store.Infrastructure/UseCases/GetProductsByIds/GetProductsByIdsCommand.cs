using System;
using System.Collections.Generic;
using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.GetProductsByIds;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds
{
    public class GetProductsByIdsCommand : IRequest<GetProductsByIdsResponse>, IGetProductsByIds
    {
        public IEnumerable<Guid> ProductIds { get; set; } = new Guid[0];
    }
}
