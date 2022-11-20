using AudiophileEcommerceWebsite.Profiles;
using AudiophileEcommerceWebsite_Tests.Services;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures
{
    public class OrderRepositoryFixture : IDisposable
    {
        public AudiophileDbContext dbContext { get; }
        public string basketId { get; set; }
        public OrderRepository orderRepository { get; set; }
        public Mapper mapper { get; set; }
        public OrderRepositoryFixture()
        {
            dbContext = DatabaseConnection._dbContext;
            basketId = DatabaseConnection.idString;

            var shoppingBasketItems = dbContext.ShoppingBasketItems
                .Where(c => c.ShoppingBasketId == basketId)
                .ToList();

            var shoppingBasketMock = new Mock<IShoppingBasket>();
            shoppingBasketMock
                .Setup(m => m.GetShoppingBasketItems())
                .Returns(shoppingBasketItems);
            shoppingBasketMock
                .Setup(m => m.GetShoppingBasketTotal())
                .Returns(14849);

            //imapper
            mapper = ConfigureMapper.mapper;

            orderRepository = new OrderRepository(dbContext,
                shoppingBasketMock.Object, mapper);
        }
        public void Dispose()
        {
            //nr
        }
    }
}
