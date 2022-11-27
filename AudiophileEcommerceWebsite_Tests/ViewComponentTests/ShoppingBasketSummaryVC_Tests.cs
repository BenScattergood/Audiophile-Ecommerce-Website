using AudiophileEcommerceWebsite.Components;
using AudiophileEcommerceWebsite.Entities;
using AudiophileEcommerceWebsite_Tests.Services;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AudiophileEcommerceWebsite_Tests.ViewComponentTests
{
    [Collection("sequential")]
    public class ShoppingBasketSummaryVC_Tests : IDisposable
    {
        public AudiophileDbContext dbContext { get; }
        public ShoppingBasketSummary ShoppingBasketSummary { get; set; }
        public ShoppingBasketSummaryVC_Tests()
        {
            dbContext = DatabaseConnection._dbContext;
            var products = dbContext.Products.Select(c => c).ToList();
            var dbString = DatabaseConnection.idString;

            var basketItems = new List<ShoppingBasketItem>()
            {
                new ShoppingBasketItem() { Product = products[0], Quantity = 1, ShoppingBasketId = dbString },
                new ShoppingBasketItem() { Product = products[2], Quantity = 2, ShoppingBasketId = dbString },
                new ShoppingBasketItem() { Product = products[4], Quantity = 4, ShoppingBasketId = dbString },
            };

            Mock<IShoppingBasket> shoppingBasketMock = new Mock<IShoppingBasket>();
            shoppingBasketMock
                .Setup(c => c.GetShoppingBasketItems())
                .Returns(basketItems);
            ShoppingBasketSummary = new ShoppingBasketSummary(shoppingBasketMock.Object,
                ConfigureMapper.mapper);
        }

        [Fact]
        public void Invoke_ViewModelHasCorrectItems_Test()
        {
            var result = ShoppingBasketSummary.Invoke();

            var viewResult = Assert.IsType<ViewViewComponentResult>(result);
            var viewModelList = Assert.IsType
                <List<ShoppingBasketItemViewModel>>(viewResult.ViewData.Model);
            Assert.Equal("ZX7 Speaker", viewModelList[2].Product.Name);
            Assert.Equal(2, viewModelList[1].Quantity);
        }

        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
