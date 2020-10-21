using System;
using System.Collections.Generic;
using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.GetProductsByIds;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds
{
    public class GetProductsByIds : IRequest<GetProductsByIdsCommandResponse>, IGetProductsByIds
    {
        public IEnumerable<Guid> ProductIds { get; set; } = new Guid[0];
    }
}
