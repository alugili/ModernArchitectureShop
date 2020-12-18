using AutoMapper;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Domain.Order, OrderDto>();
            CreateMap<Domain.Item, ItemDto>();
        }
    }
}
