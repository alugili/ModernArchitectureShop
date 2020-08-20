using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Domain;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly StoreDbContext _dbContext;

        public CreateProductHandler(StoreDbContext dbContext) => _dbContext = dbContext;

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product { ProductId = command.ProductId, Code = command.Code, Price = command.Price, ImageUrl = command.ImageUrl };

            var entry = await _dbContext.Set<Product>().AddAsync(product, cancellationToken);

            var response = new CreateProductCommandResponse
            {
                ProductId = entry.Entity.ProductId,
                Code = entry.Entity.Code,
                Price = entry.Entity.Price
            };

            await _dbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
