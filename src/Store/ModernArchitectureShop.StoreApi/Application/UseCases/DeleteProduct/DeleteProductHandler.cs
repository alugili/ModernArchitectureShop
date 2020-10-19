using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(command.ProductId, cancellationToken);
            _productRepository.Remove(new Product { ProductId = product.ProductId });

            var deletedCount = await _productRepository.SaveChangesAsync(cancellationToken);

            return deletedCount > 0;
        }
    }
}
