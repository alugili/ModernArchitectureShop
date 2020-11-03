using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                    .GetByIdsQuery(command.ProductIds)
                            .Select(x => new GetProductsByIdsResponse.ProductResult
                            {
                                Id = x.ProductId,
                                Code = x.Code,
                                Store =  new GetProductsByIdsResponse.ProductStoreResult
                                {
                                    StoreId = x.Store.StoreId,
                                    Name = x.Store.Name,
                                    CanPurchase = x.CanPurchase,
                                    Quantity = x.Quantity,
                                }
                            }).ToListAsync(cancellationToken);

            var response = new GetProductsByIdsResponse
            {
                Products = products
            };

            return response;
        }

    }
}
