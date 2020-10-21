using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;
using ModernArchitectureShop.Store.Infrastructure.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStoresHandler : IRequestHandler<GetStores, GetStoresResponse>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoresHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<GetStoresResponse> Handle(GetStores command, CancellationToken cancellationToken)
        {
            var totalOfStores = await _storeRepository.CountAsync(cancellationToken);

            var stores = await _storeRepository
                .FindStoresQuery(command.PageIndex, command.PageSize)
                .ProjectTo<StoreDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetStoresResponse
            {
                Stores = stores,
                TotalRecords = totalOfStores
            };
        }
    }
}
