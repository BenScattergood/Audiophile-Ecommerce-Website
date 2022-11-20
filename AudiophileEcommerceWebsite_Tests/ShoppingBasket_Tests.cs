
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AudiophileEcommerceWebsite_Tests
{
    [Collection("sequential")]
    public class ShoppingBasket_Tests : 
        IClassFixture<ShoppingBasketFixture>, IDisposable
    {
        private ShoppingBasket shoppingBasket;
        private List<Product> products;
        private AudiophileDbContext context;
        private string BasketId;

        public ShoppingBasket_Tests(ShoppingBasketFixture shoppingBasketFixture)
        {
            this.shoppingBasket = shoppingBasketFixture.shoppingBasket;
            context = shoppingBasketFixture.dbContext;
            products = shoppingBasketFixture.dbContext.Products
                .Select(c => c)
                .ToList();
            BasketId = shoppingBasketFixture.basketId;
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

        [Fact]
        public void AddToBasket_UpdateBasketQuantity_Test()
        {
            var product = products[0];

            shoppingBasket.AddToBasket(product, 2);

            var actual = context.ShoppingBasketItems
                .SingleOrDefault(c => c.ShoppingBasketId == BasketId
                && c.Product.ProductName == "YX1 Wireless Earphones").Quantity;

            Assert.Equal(3, actual);
        }

        [Fact]
        public void AddToBasket_AddsNewItem_Test()
        {
            var product = products[1];
            shoppingBasket.AddToBasket(product, 1);

            var actual = context.ShoppingBasketItems.
                Single(c => c.ShoppingBasketId == BasketId
                && c.Product.ProductName == "XX59 Headphones").Quantity;

            Assert.Equal(1, actual);
        }

        [Fact]
        public void RemoveFromBasket_NegatesQuantity_Test()
        {
            var product = products[2];

            shoppingBasket.RemoveFromBasket(product);

            var actual = context.ShoppingBasketItems.
                Single(c => c.ShoppingBasketId == BasketId
                && c.Product.Slug == "xx99-mark-one-headphones")
                .Quantity;

            Assert.Equal(2, actual);
        }

        [Fact]
        public void RemoveFromBasket_RemovesRow_Test()
        {
            var product = products[0];

            shoppingBasket.RemoveFromBasket(product);

            var actual = context.ShoppingBasketItems.Count();

            Assert.Equal(2, actual);
        }

        [Fact]
        public void ClearBasket_ClearsBasket_Test()
        {
            shoppingBasket.ClearBasket();

            var actual = context.ShoppingBasketItems.Count();

            Assert.Equal(0, actual);
        }

        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
