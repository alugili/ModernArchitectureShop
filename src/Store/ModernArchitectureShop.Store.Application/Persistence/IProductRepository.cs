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
        void Remove(Product product);

        void Update(Product store);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask<Product?> GetAsync(Guid id, CancellationToken cancellationToken);

        ValueTask AddAsync(Product store, CancellationToken cancellationToken);

        ValueTask<int> CountAsync(CancellationToken cancellationToken);

        IQueryable GetProductsQuery(int pageIndex, int pageSize);

        IQueryable SearchProductsQuery(string filter, int pageIndex, int pageSize);

        ValueTask<int> SearchProductsCountAsync(string filter);

        IQueryable<Product> GetByIdsQuery(IEnumerable<Guid> commandProductIds);
    }
}
