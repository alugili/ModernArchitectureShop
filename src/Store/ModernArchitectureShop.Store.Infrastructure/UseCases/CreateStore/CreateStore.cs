using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.CreateStore;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateStore
{
    public class CreateStore : IRequest<StoreDto>, ICreateStore
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
