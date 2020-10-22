using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product { ProductId = command.ProductId, Code = command.Code, Price = command.Price, ImageUrl = command.ImageUrl };

            await _productRepository.AddAsync(product, cancellationToken);
            await _productRepository.SaveChangesAsync(cancellationToken);

            var response = new CreateProductCommandResponse
            {
                ProductId = product.ProductId,
                Code = product.Code,
                Price = product.Price
            };

            return response;
        }
    }
}
