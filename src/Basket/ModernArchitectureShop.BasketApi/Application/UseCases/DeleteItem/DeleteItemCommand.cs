using System;
using MediatR;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.DeleteItem
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public Guid ItemId { get; set; }
    }
}
