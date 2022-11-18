
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests
{
    public class ShoppingBasket_Tests : 
        IClassFixture<ShoppingBasketFixture>
    {
        private ShoppingBasket shoppingBasket;

        public ShoppingBasket_Tests(ShoppingBasketFixture shoppingBasketFixture)
        {
            this.shoppingBasket = shoppingBasketFixture.shoppingBasket;
        }

        [Fact]
        public void AddToBasket_Test()
        {

        }
    }
}
