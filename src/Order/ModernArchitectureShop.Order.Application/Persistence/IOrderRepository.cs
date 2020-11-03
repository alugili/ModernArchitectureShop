using System;
using System.Linq;
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

        ValueTask<Domain.Order?> GetAsync(string username, Guid orderId, CancellationToken cancellationToken);

        ValueTask<int> CountAsync(string username, Guid orderId, CancellationToken cancellationToken);
    }
}
