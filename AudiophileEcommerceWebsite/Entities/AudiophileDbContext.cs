using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AudiophileEcommerceWebsite.Entities
{
    public class AudiophileDbContext : IdentityDbContext
    {
        public AudiophileDbContext(DbContextOptions<AudiophileDbContext>
            options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Accessory> Details { get; set; }
        public DbSet<ShoppingBasketItem> ShoppingBasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Image)
                        .WithOne(i => i.Product)
                        .HasForeignKey<Image>(i => i.ProductImageId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.CategoryImages)
                        .WithOne(i => i.CategoryProduct)
                        .HasForeignKey<Image>(i => i.CategoryProductId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Image>()
                        .HasMany(g => g.FirstGalleries)
                        .WithOne(i => i.First)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Image>()
                        .HasMany(g => g.SecondGalleries)
                        .WithOne(i => i.Second)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Image>()
                        .HasMany(g => g.ThirdGalleries)
                        .WithOne(i => i.Third)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
