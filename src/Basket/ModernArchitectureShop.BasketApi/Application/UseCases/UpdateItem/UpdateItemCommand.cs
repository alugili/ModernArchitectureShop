using System;
using MediatR;
using ModernArchitectureShop.BasketApi.Infrastructure.Dto;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.UpdateItem
{
    public class UpdateItemCommand : IRequest<ItemDto>
    {
        public Guid ProductId { get; set; }
        public string NewProductName { get; set; }
    }
}
