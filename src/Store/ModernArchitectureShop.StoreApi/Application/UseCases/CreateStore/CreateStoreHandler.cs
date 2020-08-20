using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.StoreApi.Infrastructure.Dto;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;


namespace ModernArchitectureShop.StoreApi.Application.UseCases.CreateStore
{
    public class CreateStoreHandler : IRequestHandler<CreateStoreCommand, StoreDto>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateStoreHandler(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(CreateStoreCommand command, CancellationToken cancellationToken)
        {
            var store = new Store.Domain.Store { Name = command.Name, Location = command.Location };

            var entity = await _dbContext.Set<Store.Domain.Store>().AddAsync(store, cancellationToken);

            return _mapper.Map<StoreDto>(entity.Entity);
        }
    }
}
