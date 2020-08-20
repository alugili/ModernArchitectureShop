using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.BasketApi.Application.UseCases.GetProducts;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Gateways;
using ModernArchitectureShop.BasketApi.Infrastructure.Dto;
using ModernArchitectureShop.BasketApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.GetItems
{
    internal class GetItemsHandler : IRequestHandler<GetItemsCommand, GetItemsCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly BasketDbContext _dbContext;

        public GetItemsHandler(BasketDbContext dbContext, IMapper mapper, DaprStoresGateway storesGateway)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetItemsCommandResponse> Handle(GetItemsCommand command, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Item>();

            var totalOfItems = await query.Where(i => i.Username == command.Username).CountAsync(cancellationToken);

            var items = await query.AsNoTracking()
                .OrderBy(x => x.Code)
                .Skip((command.PageIndex - 1) * command.PageSize)
                .Take(command.PageSize)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .Where(i => i.Username == command.Username)
                .ToListAsync(cancellationToken);

            var result = new GetItemsCommandResponse
            {
                Items = items,
                TotalOfItems = totalOfItems,
            };

            return result;
        }
    }
}
