using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite.Entities.SeedData;
using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite_Tests.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures.ControllerFixtures
{
    public class ShoppingBasketControllerFixture
    {
        public List<Product> products;
        public ShoppingBasketController shoppingBasketController;
        public AudiophileDbContext dbContext;
        public ShoppingBasketControllerFixture()
        {
            dbContext = DatabaseConnection._dbContext;

            products = dbContext.Products.Select(c => c).ToList();

            var productRepositoryMock = new Mock<IProductRepository>();
            var shoppingBasketMock = new Mock<IShoppingBasket>();

            shoppingBasketController = new ShoppingBasketController(shoppingBasketMock.Object,
                productRepositoryMock.Object);
        }
    }
}
