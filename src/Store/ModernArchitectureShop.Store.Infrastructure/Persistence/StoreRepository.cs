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
        private DbSet<Domain.Store> _stores;

        public StoreRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            _storeDbContext.Database.EnsureCreated();
            _stores = _storeDbContext.Set<Domain.Store>();
        }

        public void SeedDatabase()
        {
            SeedDataGenerator.GenerateSeed(_storeDbContext);
            _storeDbContext.SaveChanges();
        }

        public void Remove(Domain.Store store)
        {
            _stores.Remove(store);
        }

        public void Update(Domain.Store store)
        {
            _stores.Update(store);
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

        public async ValueTask<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _stores.CountAsync(cancellationToken);
        }

        public IQueryable<Domain.Store> GetStoreQuery()
        {
            return _stores
                .AsNoTracking()
                .Include(x => x.Products)
                .Include(x => x.Addresses);
        }
    }
}
