using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Persistence
{
    public sealed class StoreDbContext : DbContext
    {
        public DbSet<Store.Domain.Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductStore> ProductsStores { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStore>()
                .HasKey(bc => new { bc.ProductId, bc.StoreId });

            modelBuilder.Entity<ProductStore>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductStores)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductStore>()
                .HasOne(bc => bc.Store)
                .WithMany(c => c.ProductStores)
                .HasForeignKey(bc => bc.StoreId);

            var (products, stores, productStores) = SeedDataGenerator.GenerateSeed();

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Store.Domain.Store>().HasData(stores);
            modelBuilder.Entity<ProductStore>().HasData(productStores);

            base.OnModelCreating(modelBuilder);
        }
    }
}
