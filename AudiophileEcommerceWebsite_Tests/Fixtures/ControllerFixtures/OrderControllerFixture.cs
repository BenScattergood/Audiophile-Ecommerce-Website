using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite.Entities.SeedData;
using AudiophileEcommerceWebsite_Tests.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudiophileEcommerceWebsite.Services;

namespace AudiophileEcommerceWebsite_Tests.Fixtures.ControllerFixtures
{
    public class OrderControllerFixture : IDisposable
    {
        public List<Product> products;
        public OrderController orderControllerWithCallback;
        public OrderController orderControllerWithoutCallback;
        public AudiophileDbContext dbContext;
        public string idString;
        public List<OrderDetail> orderDetails;
        public OrderViewModel orderViewModel;
        public OrderControllerFixture()
        {
            dbContext = DatabaseConnection._dbContext;
            idString = DatabaseConnection.idString;
            products = dbContext.Products.Select(c => c).ToList();
            var order = new Order();
            orderDetails = new List<OrderDetail>()
            {
                new OrderDetail() { Product = products[0], Quantity = 1, Price = 599 },
                new OrderDetail() { Product = products[5], Quantity = 1, Price = 4500 },
                new OrderDetail() { Product = products[4], Quantity = 2, Price = 7000 },
            };

            orderViewModel = new OrderViewModel()
            {
                Name = "John Smith",
                EmailAddress = "JohnSmith@outlook.com",
                PhoneNumber = "07921588822",
                Address = "66 Highfield Drive",
                ZIPCode = "CW9 5TP",
                City = "Crewe",
                Country = "England",
                PaymentMethod = PaymentMethod.cash,
            };

            SetupOrderControllerWithCallback();
            SetupOrderControllerWithoutCallback();
        }

        private void SetupOrderControllerWithoutCallback()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var validateOrderMock = new Mock<IValidateOrder>();
            orderRepositoryMock.Setup(m => m.RetrieveOrderDetails(It.IsAny<Order>()));
            validateOrderMock.Setup(m => m.IsValid(It.IsAny<int>()))
                .Returns(() => true);

            orderControllerWithoutCallback = new OrderController(orderRepositoryMock.Object,
                ConfigureMapper.mapper, validateOrderMock.Object);
        }

        private void SetupOrderControllerWithCallback()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var validateOrderMock = new Mock<IValidateOrder>();
            orderRepositoryMock.Setup(m => m.RetrieveOrderDetails(It.IsAny<Order>()))
                .Callback<Order>(o => o.OrderDetails.AddRange(orderDetails));
            validateOrderMock.Setup(m => m.IsValid(It.IsAny<int>()))
                .Returns(() => true);

            orderControllerWithCallback = new OrderController(orderRepositoryMock.Object,
                ConfigureMapper.mapper, validateOrderMock.Object);
        }

        public void Dispose()
        {
            //nr
        }
    }
}
