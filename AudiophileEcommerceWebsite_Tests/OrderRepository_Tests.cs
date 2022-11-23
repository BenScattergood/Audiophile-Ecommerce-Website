using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests
{
    [Collection("sequential")]
    public class OrderRepository_Tests :
        IClassFixture<OrderRepositoryFixture>, IDisposable
    {
        private OrderRepository orderRepository_WithMock;
        private AudiophileDbContext _dbContext;
        private Mapper _mapper;
        private Order order;
        private string basketId;
        private OrderRepository orderRepository_WithIntegration;
        private OrderRepository orderRepository_WithError;

        public OrderRepository_Tests(
            OrderRepositoryFixture orderRepositoryFixture)
        {   
            _dbContext = orderRepositoryFixture.dbContext;
            _mapper = orderRepositoryFixture.mapper;
            order = orderRepositoryFixture.order;
            basketId = orderRepositoryFixture.basketId;
            this.orderRepository_WithMock = 
                orderRepositoryFixture.orderRepository_WithMock;
            orderRepository_WithIntegration = 
                orderRepositoryFixture.orderRepository_WithIntegration;
            orderRepository_WithError = 
                orderRepositoryFixture.orderRepository_WithError;
        }

        [Fact]
        public void OrderDetailMapper_Test()
        {
            var items = _dbContext.ShoppingBasketItems
                .Select(c => c)
                .ToList();

            var orderDetails = _mapper.Map<List<OrderDetail>>(items);
            Assert.Equal(items[0].Product.ProductName, 
                orderDetails[0].Product.ProductName);
        }

        [Fact]
        public void CreateOrder_AddsNewOrder_Test()
        {
            orderRepository_WithMock.CreateOrder(order);

            var actual = _dbContext.Orders
                .Single(c => c.Address == "66 Highfield Drive");

            Assert.True((Decimal)4968.8 == actual.OrderGrandTotal);
        }

        [Fact]
        public void RetrieveOrderDetails_PopulatedPriceCorrectly_Test()
        {
            var order = new Order();
            orderRepository_WithMock.RetrieveOrderDetails(order);

            var actual = order.OrderDetails[2].Price;

            Assert.Equal(9000, actual);
        }

        [Fact]
        public void RetrieveOrderDetails_CorrectCountOfOrderDetail_Test()
        {
            var order = new Order();
            orderRepository_WithMock.RetrieveOrderDetails(order);

            var actual = order.OrderDetails.Count;

            Assert.Equal(3, actual);
        }

        [Fact]
        public void ProcessOrder_ProcessedCorrectly_IntegrationTest()
        {
            var emailAddress = order.EmailAddress;
            orderRepository_WithIntegration.ProcessOrder(order);

            var actual = _dbContext.Orders.FirstOrDefault(o => o.EmailAddress == emailAddress);
            Assert.NotNull(actual);
        }

        [Fact]
        public void ProcessOrder_ClearsShoppingBasket_IntegrationTest()
        {
            orderRepository_WithIntegration.ProcessOrder(order);
            var items = _dbContext.ShoppingBasketItems.Where(item => item.ShoppingBasketId == basketId);
            Assert.Empty(items);
        }

        [Fact]
        public void ProcessOrder_OnErrorRollsBackChanges_IntegrationTest()
        {
            var emailAddress = order.EmailAddress;

            Assert.Throws<DbUpdateConcurrencyException>(() => orderRepository_WithError.ProcessOrder(order));
            Assert.Empty(_dbContext.Orders.Where(o => o.EmailAddress == emailAddress));
        }
        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
