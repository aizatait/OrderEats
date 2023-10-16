using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderEats.Core.Models;

namespace OrderEats.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<PromoCode> PromoCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(i => i.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(i => i.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is TrackingEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            var utcNow = DateTime.UtcNow;

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((TrackingEntity)entityEntry.Entity).CreatedAt = utcNow;
                    ((TrackingEntity)entityEntry.Entity).CreatedById = 1;
                }
                else
                {
                    Entry((TrackingEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((TrackingEntity)entityEntry.Entity).Property(p => p.CreatedById).IsModified = false;
                }

                ((TrackingEntity)entityEntry.Entity).UpdatedAt = utcNow;
                ((TrackingEntity)entityEntry.Entity).UpdatedById = 1;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
