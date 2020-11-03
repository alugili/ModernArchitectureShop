using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.GetStores;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStoreCommand : IRequest<GetStoreResponse>, IGetStore
    {
    }
}
