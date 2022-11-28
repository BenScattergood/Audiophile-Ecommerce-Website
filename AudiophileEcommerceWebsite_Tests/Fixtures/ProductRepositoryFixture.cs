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
        public Product Product { get; }
        public ProductRepositoryFixture()
        {
            var dbContext = DatabaseConnection._dbContext;
            productRepository = new ProductRepository(dbContext);
            categories = dbContext.Categories.ToList();
            Product = dbContext.Products.Select(c => c).ToList()[0];
        }
        public void Dispose()
        {
            // NR
        }
    }
}
