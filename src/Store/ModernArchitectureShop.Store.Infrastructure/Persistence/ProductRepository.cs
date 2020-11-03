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
        private readonly DbSet<Domain.Store> _stores;


        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            _products = _storeDbContext.Set<Product>();
            _stores = _storeDbContext.Set<Domain.Store>();
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

        public IQueryable GetProductsQuery(int pageIndex, int pageSize)
        {
            return _products
                .AsNoTracking()
                .OrderBy(x => x.Code)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Store);
        }

        public IQueryable SearchProductsQuery(string filter, int pageIndex, int pageSize)
        {
            return _products
                .AsNoTracking()
                .Where(x => x.Name.Contains(filter) || x.Code.Contains(filter))
                .OrderBy(x => x.Code)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Store);
        }

        public async ValueTask<int> SearchProductsCountAsync(string filter)
        {
            return await _products
                .AsNoTracking()
                .Where(x => x.Name.Contains(filter) || x.Code.Contains(filter)).CountAsync();
        }

        public IQueryable<Product> GetByIdsQuery(IEnumerable<Guid> productIds)
        {
            return _products
                .AsNoTracking()
                .Include(x => x.Store)
                .Where(p => productIds.Any(id => p.ProductId == id));
        }
    }
}
