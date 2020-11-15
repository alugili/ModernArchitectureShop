using System;
using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.AddItem;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.AddItem
{
    public class AddItemCommand : IRequest<ItemDto>, IAddItem
    {
        public Guid ItemId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
