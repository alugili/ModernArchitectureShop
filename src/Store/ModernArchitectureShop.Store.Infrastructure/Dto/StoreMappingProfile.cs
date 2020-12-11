using AutoMapper;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class StoreMappingProfile : Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<Domain.Store, StoreDto>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.AddressId));
        }
    }
}
