using System;
using AutoMapper;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order.Domain.Order, OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => (Guid)src.OrderId));

            CreateMap<Order.Domain.Item, ItemDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => (Guid)src.ItemId));
        }
    }
}
