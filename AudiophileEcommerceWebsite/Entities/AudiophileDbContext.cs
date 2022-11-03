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
                        .HasMany(i => i.FirstGalleries)
                        .WithMany(g => g.First)
                        .UsingEntity(pi => pi.ToTable("GalleryFirstImage"));

            modelBuilder.Entity<Image>()
                        .HasMany(i => i.SecondGalleries)
                        .WithMany(g => g.Second)
                        .UsingEntity(pi => pi.ToTable("GallerySecondImage"));

            modelBuilder.Entity<Image>()
                        .HasMany(i => i.ThirdGalleries)
                        .WithMany(g => g.Third)
                        .UsingEntity(pi => pi.ToTable("GalleryThirdImage"));
        }
    }
}
