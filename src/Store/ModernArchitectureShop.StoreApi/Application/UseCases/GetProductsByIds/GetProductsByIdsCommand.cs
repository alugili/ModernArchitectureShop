using System;
using System.Collections.Generic;
using MediatR;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProductsByIds
{
    public class GetProductsByIdsCommand : IRequest<GetProductsByIdsCommandResponse>
    {
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
