using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<bool> Handle(DeleteProduct command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(command.ProductId, cancellationToken);

            if (product != null)
            {
                _productRepository.Remove(new Product { ProductId = product.ProductId });
                var deletedCount = await _productRepository.SaveChangesAsync(cancellationToken);
                return deletedCount > 0;

            }
            return false;
        }
    }
}
