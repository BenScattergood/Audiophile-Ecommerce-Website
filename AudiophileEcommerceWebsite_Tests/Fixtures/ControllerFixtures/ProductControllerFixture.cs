using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite.Entities.SeedData;
using AudiophileEcommerceWebsite_Tests.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures.ControllerFixtures
{
    public class ProductControllerFixture
    {
        public List<Product> products;
        public List<Category> categories;
        public ProductController productController;
        public AudiophileDbContext dbContext;
        public ProductControllerFixture()
        {
            dbContext = DatabaseConnection._dbContext;

            products = dbContext.Products.Select(c => c).ToList();

            categories = Categories.GetCategories();

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(c => c.GetAllProducts())
                .Returns(products);
            productRepositoryMock.Setup(c => c.GetProductsFromCategory(It.IsAny<string>()))
                .Returns(products
                .Where(p => p.Category.CategoryName.ToLower() == "headphones")
                .ToList());
            productRepositoryMock.Setup(c => c.GetProductById(It.IsAny<int>()))
                .Returns(products[1]);


            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<ProductController>();
            productController = new ProductController(productRepositoryMock.Object,
                ConfigureMapper.mapper, logger);
        }
    }
}
