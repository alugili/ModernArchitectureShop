using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStoresHandler : IRequestHandler<GetStoreCommand, GetStoreResponse>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoresHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<GetStoreResponse> Handle(GetStoreCommand command, CancellationToken cancellationToken)
        {
            var store = await _storeRepository
                .GetStoreQuery()
                .ProjectTo<StoreDto>(_mapper.ConfigurationProvider)
                .SingleAsync(cancellationToken);

            return new GetStoreResponse
            {
                Store = store,
            };
        }
    }
}
