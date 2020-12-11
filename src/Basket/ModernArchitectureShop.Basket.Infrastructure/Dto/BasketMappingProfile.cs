using AutoMapper;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Dto
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<Domain.Basket, BasketDto>();
            CreateMap<Item, ItemDto>();
        }
    }
}
