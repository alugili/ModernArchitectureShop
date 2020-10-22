using System;
using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.DeleteItem;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.DeleteItem
{
    public class DeleteItemCommand : IRequest<bool>, IDeleteItem
    {
        public Guid ItemId { get; set; }
    }
}
