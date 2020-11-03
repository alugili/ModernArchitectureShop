using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.Persistence
{
    public sealed class StoreDbContext : DbContext
    {
        public DbSet<Domain.Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Domain.Address> Addresses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public StoreDbContext(DbContextOptions options) : base(options)
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
