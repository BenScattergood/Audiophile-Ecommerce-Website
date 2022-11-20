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
        public AudiophileDbContext dbContext { get; }
        public string basketId { get; set; }
        public ShoppingBasketFixture()
        {
            dbContext = DatabaseConnection._dbContext;

            basketId = DatabaseConnection.idString;
            var sessionMock = new Mock<ISession>();
            var idBytes = Encoding.UTF8.GetBytes(basketId);
            sessionMock
                .Setup(s => s.TryGetValue(It.IsAny<string>(), out idBytes));

            ISession session = sessionMock.Object;

            shoppingBasket = new ShoppingBasket(session, dbContext);
        }

        public void Dispose()
        {
            //nr
        }
    }
}
