using System;
using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.CreateStore;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateStore
{
    public class CreateStoreCommand : IRequest<StoreDto>, ICreateStore
    {
        public string Name { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
