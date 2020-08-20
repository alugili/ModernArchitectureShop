using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly StoreDbContext _dbContext;

        public DeleteProductHandler(StoreDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstAsync(x => x.ProductId == command.ProductId);

            _dbContext.Products.Remove(product);


            var deletedCount = await _dbContext.SaveChangesAsync(cancellationToken);

            return deletedCount > 0;
        }
    }
}
