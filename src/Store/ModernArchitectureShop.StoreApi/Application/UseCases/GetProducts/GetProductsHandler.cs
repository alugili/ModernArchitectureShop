using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Domain;
using ModernArchitectureShop.StoreApi.Infrastructure.Dto;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, GetProductsCommandResponse>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductsHandler(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetProductsCommandResponse> Handle(GetProductsCommand command, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Product>();

            var totalOfProducts = await query.CountAsync(cancellationToken);

            var products = await query.AsNoTracking()
                .OrderBy(x => x.Code)
                .Skip((command.PageIndex - 1) * command.PageSize)
                .Take(command.PageSize)
                .Include(x => x.ProductStores)
                .ThenInclude(x => x.Store)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var result = new GetProductsCommandResponse
            {
                Products = products,
                TotalOfProducts = totalOfProducts
            };

            return result;
        }
    }
}
