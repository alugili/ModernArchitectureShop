using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Persistence
{
    public class ItemRepository : IItemRepository
    {
        private readonly BasketDbContext _basketDbContext;
        private readonly DbSet<Item> _items;

        public ItemRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
            _items = _basketDbContext.Set<Item>();
        }

        public void CreateDatabase()
        {
            _basketDbContext.Database.EnsureCreated();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _basketDbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<Item?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _items.SingleOrDefaultAsync(x => x.ItemId == id, cancellationToken: cancellationToken);
        }

        public async ValueTask AddAsync(Item item, CancellationToken cancellationToken)
        {
            await _items.AddAsync(item, cancellationToken);
        }

        public void Remove(Item item)
        {
             _items.Remove(item);
        }

        public void Update(Item item)
        {
            _items.Update(item);
        }

        public async ValueTask<ICollection<Item>> GetAsync(string username, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _items.AsNoTracking()
                         .OrderBy(x => x.Code)
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .Where(i => i.Username == username)
                         .ToListAsync(cancellationToken);
        }

        public async ValueTask<int> TotalCountAsync(string username, CancellationToken cancellationToken)
        {
            return await _items.Where(i => i.Username == username).CountAsync(cancellationToken);

        }
    }
}
