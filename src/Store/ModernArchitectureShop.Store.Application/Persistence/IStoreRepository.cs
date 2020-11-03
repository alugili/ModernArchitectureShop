using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModernArchitectureShop.Store.Application.Persistence
{
    public interface IStoreRepository
    {
        void SeedDatabase();
        void Remove(Domain.Store store);

        void Update(Domain.Store store);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask<Domain.Store?> GetAsync(Guid id, CancellationToken cancellationToken);

        ValueTask AddAsync(Domain.Store store, CancellationToken cancellationToken);
    
        ValueTask<int> CountAsync(CancellationToken cancellationToken);

        IQueryable<Domain.Store> GetStoreQuery();
    }
}
