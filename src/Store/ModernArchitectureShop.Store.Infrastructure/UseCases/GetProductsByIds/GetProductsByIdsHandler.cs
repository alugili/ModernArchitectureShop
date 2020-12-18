using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds
{
    public class GetProductsByIdsHandler : IRequestHandler<GetProductsByIdsCommand, GetProductsByIdsResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByIdsHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<GetProductsByIdsResponse> Handle(GetProductsByIdsCommand command, CancellationToken cancellationToken)
        {
            var products = await _productRepository
                    .GetByIdsAsync(command.ProductIds, cancellationToken);

            var productsResponse = products.Select(x =>
                new GetProductsByIdsResponse.ProductResult
                {
                    Id = x.ProductId,
                    Code = x.Code,
                    Store = new GetProductsByIdsResponse.ProductStoreResult
                    {
                        StoreId = x.Store.StoreId,
                        Name = x.Store.Name,
                        CanPurchase = x.CanPurchase,
                        Quantity = x.Quantity,
                    }
                });

            var response = new GetProductsByIdsResponse
            {
                Products = productsResponse
            };

            return response;
        }

    }
}
