using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateStore
{
    public class CreateStoreHandler : IRequestHandler<CreateStoreCommand, StoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoreHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(CreateStoreCommand command, CancellationToken cancellationToken)
        {
            // address todo
            var store = new Domain.Store { Name = command.Name};
            await _storeRepository.AddAsync(store, cancellationToken);

            return _mapper.Map<StoreDto>(store);
        }
    }
}
