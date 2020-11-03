using AutoMapper;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductId,
                    arg => arg.MapFrom(src => src.ProductId));

            CreateMap<Domain.Store, StoreDto>()
                .ForMember(dest => dest.StoreId,
                    arg => arg.MapFrom(src => src.StoreId));

            CreateMap<Domain.Address, AddressDto>()
                .ForMember(dest => dest.AddressId,
                    arg => arg.MapFrom(src => src.AddressId));
        }
    }
}
