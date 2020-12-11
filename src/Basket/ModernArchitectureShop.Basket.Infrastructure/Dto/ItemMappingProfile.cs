using System;
using AutoMapper;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.Basket.Infrastructure.UseCases.AddItem;

namespace ModernArchitectureShop.Basket.Infrastructure.Dto
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<AddItemCommand, Item>();
        }
    }
}
