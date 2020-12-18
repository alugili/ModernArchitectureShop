using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly DbSet<Domain.Order> _orders;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            _orders = _orderDbContext.Set<Domain.Order>();
        }

        public void CreateDatabase()
        {
            _orderDbContext.Database.EnsureCreated();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _orderDbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask AddAsync(Domain.Order order, CancellationToken cancellationToken)
        {
            await _orders.AddAsync(order, cancellationToken);
        }

        public void Remove(Domain.Order order)
        {
            _orders.Remove(order);
        }

        public void Update(Domain.Order order)
        {
            _orders.Update(order);
        }

        public async ValueTask<ICollection<Domain.Order>> GetAsync(string username, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _orders.AsNoTracking()
                         .OrderBy(x => x.CreationDate)
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .Where(i => i.Username == username)
                         .ToListAsync(cancellationToken);
        }

        public async ValueTask<Domain.Order?> GetProcessingAsync(string username, CancellationToken cancellationToken)
        {
            return await _orders.SingleOrDefaultAsync(x =>
                                                           x.Username == username &&
                                                           x.State == State.Processing,
                                                           cancellationToken: cancellationToken);
        }

        public async ValueTask<IList<Domain.Order>> GetCompletedAsync(string username, CancellationToken cancellationToken)
        {
          return await _orders.Include(o=>o.Items)
                              .Where(o =>
                                               o.Username == username &&
                                               o.State == State.Completed
                                     )
                              .ToListAsync(cancellationToken);

        }

        public async ValueTask<int> CountAsync(string username, CancellationToken cancellationToken)
        {
            return await _orders.Where(i => i.Username == username).CountAsync(cancellationToken);
        }
    }
}
