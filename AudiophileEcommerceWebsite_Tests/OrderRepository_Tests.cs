using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests
{
    [Collection("sequential")]
    public class OrderRepository_Tests :
        IClassFixture<OrderRepositoryFixture>, IDisposable
    {
        private OrderRepository orderRepository;
        private AudiophileDbContext _dbContext;
        private Mapper _mapper;

        public OrderRepository_Tests(
            OrderRepositoryFixture orderRepositoryFixture)
        {
            this.orderRepository = orderRepositoryFixture.orderRepository;
            _dbContext = orderRepositoryFixture.dbContext;
            _mapper = orderRepositoryFixture.mapper;
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
            var products = _dbContext.Products
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

            var order = new Order()
            {
                Name = "John Smith",
                EmailAddress = "JohnSmith@outlook.com",
                PhoneNumber = "07921588822",
                Address = "66 Highfield Drive",
                ZIPCode = "CW9 5TP",
                City = "Crewe",
                Country = "England",
                OrderProductTotal = 4099,
                OrderTime = DateTime.Now,
                OrderDetails = orderDetails,
            };

            orderRepository.CreateOrder(order);

            var actual = _dbContext.Orders
                .Single(c => c.Address == "66 Highfield Drive")
                .OrderGrandTotal;

            Assert.True((Decimal)4968.8 == actual);
        }

        [Fact]
        public void GetOrderSummary_PopulatedPriceCorrectly_Test()
        {
            var order = new Order();
            orderRepository.UpdateOrderDetails(order);

            var actual = order.OrderDetails[2].Price;

            Assert.Equal(9000, actual);
        }

        [Fact]
        public void GetOrderSummary_CorrectCountOfOrderDetail_Test()
        {
            var order = new Order();
            orderRepository.UpdateOrderDetails(order);

            var actual = order.OrderDetails.Count;

            Assert.Equal(3, actual);
        }
        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
