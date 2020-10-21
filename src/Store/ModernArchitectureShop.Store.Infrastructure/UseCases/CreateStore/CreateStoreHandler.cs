using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateStore
{
    public class CreateStoreHandler : IRequestHandler<CreateStore, StoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoreHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(CreateStore command, CancellationToken cancellationToken)
        {
            var store = new Store.Domain.Store { Name = command.Name, Location = command.Location };
            await _storeRepository.AddAsync(store, cancellationToken);

            return _mapper.Map<StoreDto>(store);
        }
    }
}
