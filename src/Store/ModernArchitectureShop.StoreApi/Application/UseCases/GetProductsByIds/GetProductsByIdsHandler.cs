using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Domain;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProductsByIds
{
    public class GetProductsByIdsHandler : IRequestHandler<GetProductsByIdsCommand, GetProductsByIdsCommandResponse>
    {
        private readonly StoreDbContext _dbContext;

        public GetProductsByIdsHandler(StoreDbContext dbContext) => _dbContext = dbContext;

        public async Task<GetProductsByIdsCommandResponse> Handle(GetProductsByIdsCommand command, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Product>();

            var products = await query.AsNoTracking()
                .Include(p => p.ProductStores)
                .ThenInclude(x => x.Store)
                .Where(p => command.ProductIds.Any(id => p.ProductId == id))
                .Select(x => new GetProductsByIdsCommandResponse.ProductResult
                {
                    Id = x.ProductId,
                    Code = x.Code,
                    Stores = x.ProductStores.Select(i => new GetProductsByIdsCommandResponse.ProductStoreResult
                    {
                        StoreId = i.Store.StoreId,
                        Name = i.Store.Name,
                        Location = i.Store.Location,
                        CanPurchase = i.CanPurchase,
                        Quantity = i.Quantity
                    })
                }).ToListAsync(cancellationToken);

            var response = new GetProductsByIdsCommandResponse
            {
                Products = products
            };

            return response;
        }

    }
}
