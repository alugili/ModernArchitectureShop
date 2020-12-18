using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly DbSet<Product> _products;


        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            _products = _storeDbContext.Set<Product>();
        }

        public void Remove(Product product)
        {
            _products.Remove(product);
        }

        public void Update(Product product)
        {
            _products.Update(product);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _storeDbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<Product?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _products.SingleOrDefaultAsync(x => x.ProductId == id, cancellationToken: cancellationToken);
        }

        public async ValueTask AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _products.AddAsync(product, cancellationToken);
        }

        public async ValueTask<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _products.CountAsync(cancellationToken);
        }

        public async ValueTask<IList<Product>> GetProductsAsync(int pageIndex, int pageSize, CancellationToken cancellation)
        {
            return await _products
                                   .AsNoTracking()
                                   .OrderBy(x => x.Code)
                                   .Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .Include(x => x.Store)
                                   .ToListAsync(cancellation);
        }

        public async ValueTask<IList<Product>> SearchProductsAsync(string filter,
                                                                   int pageIndex,
                                                                   int pageSize,
                                                                   CancellationToken cancellation)
        {
            return await _products
                                  .AsNoTracking()
                                  .Where(x => x.Name.Contains(filter) || x.Code.Contains(filter))
                                  .OrderBy(x => x.Code)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .Include(x => x.Store)
                                 .ToListAsync(cancellation);
        }

        public async ValueTask<int> SearchProductsCountAsync(string filter)
        {
            return await _products
                .AsNoTracking()
                .Where(x => x.Name.Contains(filter) || x.Code.Contains(filter)).CountAsync();
        }

        public async ValueTask<IList<Product>> GetByIdsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken)
        {
            return await _products
                             .AsNoTracking()
                             .Include(x => x.Store)
                             .Where(p => productIds.Any(id => p.ProductId == id))
                             .ToListAsync(cancellationToken);

        }
    }
}
