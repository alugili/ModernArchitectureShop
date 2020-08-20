using System;
using AutoMapper;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Dto
{
    public class StoreMappingProfile : Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<Store.Domain.Store, StoreDto>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId));

            CreateMap<ProductStore, ProductStoreDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId));
        }
    }
}
