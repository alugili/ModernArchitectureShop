using System;
using MediatR;
using ModernArchitectureShop.BasketApi.Infrastructure.Dto;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.AddItem
{
    public class AddItemCommand : IRequest<ItemDto>
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
        public Guid StoreId { get; set; }
    }
}
