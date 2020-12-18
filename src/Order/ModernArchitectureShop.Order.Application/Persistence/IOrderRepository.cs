using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ModernArchitectureShop.Order.Application.Persistence
{
    public interface IOrderRepository
    {
        void CreateDatabase();

        void Remove(Domain.Order order);

        void Update(Domain.Order order);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask AddAsync(Domain.Order store, CancellationToken cancellationToken);

        ValueTask<Domain.Order?> GetProcessingAsync(string username, CancellationToken cancellationToken);

        ValueTask<IList<Domain.Order>> GetCompletedAsync(string username, CancellationToken cancellationToken);

        ValueTask<int> CountAsync(string username, CancellationToken cancellationToken);
    }
}
