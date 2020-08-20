using System;
using AutoMapper;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Dto
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductId,
                    arg => arg.MapFrom(src => (Guid)src.ProductId));

            CreateMap<ProductStore, ProductStoreDto>()
                .ForMember(dest => dest.StoreId, arg => arg.MapFrom(src => (Guid)src.Store.StoreId))
                .ForMember(dest => dest.ProductId, arg => arg.MapFrom(src => src.ProductId));
        }
    }
}
