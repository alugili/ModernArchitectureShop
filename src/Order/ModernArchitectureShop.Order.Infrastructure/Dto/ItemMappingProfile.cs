using AutoMapper;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order.Domain.Order, OrderDto>();
            CreateMap<Order.Domain.Item, ItemDto>();
        }
    }
}
