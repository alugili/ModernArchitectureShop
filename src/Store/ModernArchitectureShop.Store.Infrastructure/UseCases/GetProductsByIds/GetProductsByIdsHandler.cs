using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds
{
    public class GetProductsByIdsHandler : IRequestHandler<GetProductsByIdsCommand, GetProductsByIdsResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByIdsHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<GetProductsByIdsResponse> Handle(GetProductsByIdsCommand command, CancellationToken cancellationToken)
        {
            var products = await _productRepository
                    .GetByIdsQuery(command.ProductIds)
                            .Select(x => new GetProductsByIdsResponse.ProductResult
                            {
                                Id = x.ProductId,
                                Code = x.Code,
                                Stores = x.ProductStores.Select(i => new GetProductsByIdsResponse.ProductStoreResult
                                {
                                    StoreId = i.Store.StoreId,
                                    Name = i.Store.Name,
                                    Location = i.Store.Location,
                                    CanPurchase = i.CanPurchase,
                                    Quantity = i.Quantity
                                })
                            }).ToListAsync(cancellationToken);

            var response = new GetProductsByIdsResponse
            {
                Products = products
            };

            return response;
        }

    }
}
