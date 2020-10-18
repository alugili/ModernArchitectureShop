using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Application.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.Persistence
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly DbSet<Domain.Store> _stores;

        public StoreRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            _stores = _storeDbContext.Set<Domain.Store>();
        }

        public void CreateDatabase()
        {
            _storeDbContext.Database.EnsureCreated();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _storeDbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<Domain.Store?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _stores.SingleOrDefaultAsync(x => x.StoreId == id, cancellationToken: cancellationToken);
        }

        public async ValueTask AddAsync(Domain.Store store, CancellationToken cancellationToken)
        {
            await _stores.AddAsync(store, cancellationToken);
        }

        public async ValueTask RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            await _stores.SingleAsync(x => x.StoreId == id, cancellationToken: cancellationToken);
        }

        public void Update(Domain.Store store)
        {
            _stores.Update(store);
        }

        public async ValueTask<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _stores.CountAsync(cancellationToken);
        }

        public IQueryable<Domain.Store> FindStoresQuery(int pageIndex, int pageSize)
        {
            return _stores
                  .AsNoTracking()
                  .Include(x => x.ProductStores)
                  .ThenInclude(x => x.Product)
                  .OrderBy(x => x.Name)
                  .Skip((pageIndex - 1) * pageSize)
                  .Take(pageSize);
        }
    }
}
