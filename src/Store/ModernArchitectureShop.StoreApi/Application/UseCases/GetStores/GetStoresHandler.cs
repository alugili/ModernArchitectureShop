using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.StoreApi.Infrastructure.Dto;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetStores
{
    public class GetStoresHandler : IRequestHandler<GetStoresCommand, GetStoresResponse>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStoresHandler(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetStoresResponse> Handle(GetStoresCommand command, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Store.Domain.Store>();

            var totalOfStores = await query.CountAsync(cancellationToken);

            var stores = await query.AsNoTracking()
                .Include(x => x.ProductStores)
                .ThenInclude(x => x.Product)
                .OrderBy(x => x.Name)
                .Skip((command.PageIndex - 1) * command.PageSize)
                .Take(command.PageSize)
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
