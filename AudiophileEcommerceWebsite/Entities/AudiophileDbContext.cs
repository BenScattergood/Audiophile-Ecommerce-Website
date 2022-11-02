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
    }
}
