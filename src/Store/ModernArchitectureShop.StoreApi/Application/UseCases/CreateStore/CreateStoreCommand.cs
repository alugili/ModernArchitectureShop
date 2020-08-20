using MediatR;
using ModernArchitectureShop.StoreApi.Infrastructure.Dto;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.CreateStore
{
    public class CreateStoreCommand : IRequest<StoreDto>
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
