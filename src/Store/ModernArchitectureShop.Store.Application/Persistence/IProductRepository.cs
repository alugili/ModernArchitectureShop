using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Application.Persistence
{
    public interface IProductRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask<Domain.Product?> GetAsync(Guid id, CancellationToken cancellationToken);

        ValueTask AddAsync(Domain.Product store, CancellationToken cancellationToken);

        ValueTask RemoveAsync(Guid id, CancellationToken cancellationToken);

        void Update(Domain.Product store);

        ValueTask<int> CountAsync(CancellationToken cancellationToken);

        IQueryable GetProductsQuery(int pageIndex, int pageSize);

        IQueryable<Product> GetByIdsQuery(IEnumerable<Guid> commandProductIds);
    }
}
