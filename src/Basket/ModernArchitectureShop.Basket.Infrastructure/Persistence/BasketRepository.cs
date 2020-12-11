using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Persistence
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _basketDbContext;

        private readonly DbSet<Domain.Basket> _baskets;

        public BasketRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
            _baskets = _basketDbContext.Set<Domain.Basket>();
        }

        public void CreateDatabase()
        {
            _basketDbContext.Database.EnsureCreated();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _basketDbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<Domain.Basket?> GetBasketSingeOrDefault(string username, CancellationToken cancellationToken)
        {
            return await _baskets
                                .Include(x => x.Items)
                                .SingleOrDefaultAsync(x => x.Username == username && x.State == State.Unlocked, cancellationToken: cancellationToken);
        }

        public async ValueTask AddAsync(Domain.Basket basket, CancellationToken cancellationToken)
        {
            await _baskets.AddAsync(basket, cancellationToken);
        }

        public void Remove(Domain.Basket basket)
        {
            _baskets.Remove(basket);
        }

        public void Update(Domain.Basket basket)
        {
            _baskets.Update(basket);
        }

        public async ValueTask<Domain.Basket> GetAsync(string username, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _baskets.AsNoTracking()
                         .Include(x => x.Items)
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .Where(i => i.Username == username)
                         .SingleOrDefaultAsync(cancellationToken);
        }

        public async ValueTask<int> TotalCountAsync(string username, CancellationToken cancellationToken)
        {
            return await _baskets.Where(i => i.Username == username).CountAsync(cancellationToken);
        }

        public async ValueTask<double> TotalPriceAsync(string username, CancellationToken cancellationToken)
        {
            return await _baskets.Where(i => i.Username == username)
                                 .SelectMany(x => x.Items)
                                 .SumAsync(x => x.Price, cancellationToken);
        }

        public void Dispose()
        {
            _basketDbContext.Dispose();
        }
    }
}
