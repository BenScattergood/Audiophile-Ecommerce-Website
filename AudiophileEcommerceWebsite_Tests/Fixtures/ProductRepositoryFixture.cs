using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures
{
    public class ProductRepositoryFixture : IDisposable
    {
        public ProductRepository productRepository { get; }
        public List<Category> categories { get; }
        public ProductRepositoryFixture()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<AudiophileDbContext>()
                        .UseSqlite(connection);

            var dbContext = new AudiophileDbContext(optionsBuilder.Options);
            dbContext.Database.EnsureCreated();


            //maybe change this...
            DbInitializer.Seed(dbContext);

            productRepository = new ProductRepository(dbContext);
            categories = dbContext.Categories.ToList();
        }
        public void Dispose()
        {
            // NR
        }
    }
}
