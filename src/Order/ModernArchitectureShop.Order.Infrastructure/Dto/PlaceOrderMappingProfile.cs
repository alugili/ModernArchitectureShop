using AutoMapper;
using ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement;

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
