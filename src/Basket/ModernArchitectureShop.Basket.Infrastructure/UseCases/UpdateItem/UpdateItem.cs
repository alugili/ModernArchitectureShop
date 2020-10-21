using System;
using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.UpdateItem;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.UpdateItem
{
    public class UpdateItem : IRequest<ItemDto>, IUpdateItem
    {
        public Guid ProductId { get; set; }
        public string NewProductName { get; set; } = string.Empty;
    }
}
