using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite_Tests.Fixtures.ControllerFixtures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.ControllerTests
{
    [Collection("sequential")]
    public class ShoppingBasketController_Tests : IDisposable, 
        IClassFixture<ShoppingBasketControllerFixture>
    {
        public List<Product> products;
        public ShoppingBasketController shoppingBasketController;
        public AudiophileDbContext dbContext;
        public ShoppingBasketController_Tests(ShoppingBasketControllerFixture 
            shoppingBasketControllerFixture)
        {
            products = shoppingBasketControllerFixture.products;
            shoppingBasketController = shoppingBasketControllerFixture
                .shoppingBasketController;
            dbContext = shoppingBasketControllerFixture.dbContext;
        }
                
        [Fact]
        public void UpdateShoppingBasketItemHome_QuantityGreaterThanZero_Test()
        {
            var result = shoppingBasketController.UpdateShoppingBasketItemHome(
                1, products[5].ProductName);

            var expected = new RouteValueDictionary()
            {
                { "quantity", 1},
                { "productName", products[5].ProductName }
            };

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("AddToShoppingBasket", redirect.ActionName);
            Assert.Equal(expected, redirect.RouteValues);
        }

        [Fact]
        public void UpdateShoppingBasketItemHome_QuantityEqualToZero_Test()
        {
            var result = shoppingBasketController.UpdateShoppingBasketItemHome(
                0, products[5].ProductName);

            var expected = new RouteValueDictionary()
            {
                { "quantity", 0},
                { "productName", products[5].ProductName }
            };

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("DecrementFromShoppingBasket", redirect.ActionName);
            Assert.Equal(expected, redirect.RouteValues);
        }

        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
