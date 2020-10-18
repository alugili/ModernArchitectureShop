using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Application.Persistence
{
    public interface IItemRepository
    {
        void CreateDatabase();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask<Item?> GetAsync(Guid id, CancellationToken cancellationToken);

        ValueTask AddAsync(Item item, CancellationToken cancellationToken);

        ValueTask RemoveAsync(Guid id, CancellationToken cancellationToken);

        void Update(Item itemI);

        ValueTask<ICollection<Item>> GetAsync(string username,
                                              int pageIndex, int pageSize,
                                              CancellationToken cancellationToken);

        ValueTask<int> TotalCountAsync(string username, CancellationToken cancellationToken);
    }
}
