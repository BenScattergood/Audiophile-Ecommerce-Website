using AudiophileEcommerceWebsite.Profiles;
using AudiophileEcommerceWebsite_Tests.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public OrderRepository orderRepository_WithMock { get; set; }
        public OrderRepository orderRepository_WithError { get; set; }
        public Mapper mapper { get; set; }
        public Order order { get; set; }
        public OrderRepository orderRepository_WithIntegration { get; set; }
        public OrderRepositoryFixture()
        {
            dbContext = DatabaseConnection._dbContext;
            basketId = DatabaseConnection.idString;
            mapper = ConfigureMapper.mapper;

            ConfigureOrderRepsitory_WithMock();
            ConfigureOrderRepository_WithError();
            ConfigureOrderRepository_WithIntegration();
            ConfigureOrder();
        }

        private void ConfigureOrderRepsitory_WithMock()
        {
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

            orderRepository_WithMock = new OrderRepository(dbContext,
                shoppingBasketMock.Object, mapper);
        }

        private void ConfigureOrderRepository_WithError()
        {
            var shoppingBasketThrowsError = new Mock<IShoppingBasket>();
            shoppingBasketThrowsError
                .Setup(m => m.ClearBasket()).Throws(new DbUpdateConcurrencyException());

            orderRepository_WithError = new OrderRepository(dbContext,
                shoppingBasketThrowsError.Object, mapper);
        }

        private void ConfigureOrderRepository_WithIntegration()
        {
            var sessionMock = new Mock<ISession>();
            var idBytes = Encoding.UTF8.GetBytes(basketId);
            sessionMock
                .Setup(s => s.TryGetValue(It.IsAny<string>(), out idBytes));

            ISession session = sessionMock.Object;

            var IntegrationShoppingBasket = new ShoppingBasket(session, dbContext);
            orderRepository_WithIntegration = new OrderRepository(dbContext,
                IntegrationShoppingBasket, mapper);
        }

        public void ConfigureOrder()
        {
            var products = dbContext.Products
                .Select(c => c)
                .ToList();

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            orderDetails.Add(new OrderDetail()
            {
                Product = products[0],
                Quantity = 1,
                Price = products[0].Price,
            });
            orderDetails.Add(new OrderDetail()
            {
                Product = products[2],
                Quantity = 2,
                Price = products[2].Price * 2,
            });

            order = new Order()
            {
                Name = "John Smith",
                EmailAddress = "JohnSmith@outlook.com",
                PhoneNumber = "07921588822",
                Address = "66 Highfield Drive",
                ZIPCode = "CW9 5TP",
                City = "Crewe",
                Country = "England",
                OrderProductTotal = 4099,
                OrderDetails = orderDetails,
            };
        }
        public void Dispose()
        {
            //nr
        }
    }
}
