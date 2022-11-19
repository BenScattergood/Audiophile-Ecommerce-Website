using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures
{
    public class ShoppingBasketFixture : IDisposable
    {
        public ShoppingBasket shoppingBasket { get; }
        public ShoppingBasketFixture()
        {
            var dbContext = DatabaseConnection._dbContext;
            var sessionMock = new Mock<ISession>();

            sessionMock
                .Setup(s => s.TryGetValue(It.IsAny<string>(), out DatabaseConnection.idBytes));

            ISession session = sessionMock.Object;

            shoppingBasket = new ShoppingBasket(session, dbContext);
        }

        public void Dispose()
        {
            //dispose of db?
        }
    }
}
