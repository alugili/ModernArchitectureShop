using AutoMapper;
using ModernArchitectureShop.Order.Infrastructure.UseCases.AddOrder;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class PlaceOrderMappingProfile : Profile
    {
        public PlaceOrderMappingProfile()
        {
            CreateMap<PlaceOrderCommand, Domain.Order>();
        }
    }
}
