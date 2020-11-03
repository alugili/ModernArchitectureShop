using Microsoft.EntityFrameworkCore;

namespace ModernArchitectureShop.Order.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Domain.Order> Orders { get; set; } = null!;
        public DbSet<Domain.Item> Items { get; set; } = null!;


        public OrderDbContext(DbContextOptions options) : base(options)
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
