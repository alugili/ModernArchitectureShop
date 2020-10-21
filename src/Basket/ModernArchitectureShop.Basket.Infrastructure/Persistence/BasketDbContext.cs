using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.Basket.Infrastructure.Persistence
{
    public class BasketDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; } = null!;

        public BasketDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo just for testing.
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
