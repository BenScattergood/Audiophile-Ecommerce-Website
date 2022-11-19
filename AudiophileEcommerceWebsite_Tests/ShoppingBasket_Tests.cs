
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests
{
    [Collection("sequential")]
    public class ShoppingBasket_Tests : 
        IClassFixture<ShoppingBasketFixture>
    {
        private ShoppingBasket shoppingBasket;

        public ShoppingBasket_Tests(ShoppingBasketFixture shoppingBasketFixture)
        {
            this.shoppingBasket = shoppingBasketFixture.shoppingBasket;
        }

        [Fact]
        public void GetShoppingBasketItems_ReturnsCorrectItems_Test()
        {
            var items = shoppingBasket.GetShoppingBasketItems();

            Assert.Equal(3, items.Count);
            Assert.True(items[0].Product.ProductName == "YX1 Wireless Earphones");
        }

        [Fact]
        public void GetShoppingBasketTotal_ReturnsCorrectTotal_Test()
        {
            var sum = shoppingBasket.GetShoppingBasketTotal();

            Assert.Equal(14849, sum);
        }
    }
}
