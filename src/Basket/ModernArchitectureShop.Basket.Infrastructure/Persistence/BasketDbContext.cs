using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Persistence
{
    public class BasketDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public BasketDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
