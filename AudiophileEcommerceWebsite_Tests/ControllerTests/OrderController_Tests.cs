using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite_Tests.Fixtures.ControllerFixtures;
using AudiophileEcommerceWebsite_Tests.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.ControllerTests
{
    [Collection("sequential")]
    public class OrderController_Tests :
        IClassFixture<OrderControllerFixture>, IDisposable
    {
        public List<Product> products;
        public OrderController orderController;
        public AudiophileDbContext dbContext;
        public string idString;
        public List<OrderDetail> orderDetails;

        public OrderController_Tests(
            OrderControllerFixture orderControllerFixture)
        {
            products = orderControllerFixture.products;
            orderController = orderControllerFixture.orderController;
            dbContext = orderControllerFixture.dbContext;
            idString = orderControllerFixture.idString;
            orderDetails = orderControllerFixture.orderDetails;
        }

        [Fact]
        public void Checkout_BasketItemCountMoreThanOne_ReturnsView_Test()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(m => m.RetrieveOrderDetails(It.IsAny<Order>()))
                .Callback<Order>(o => o.OrderDetails.AddRange(orderDetails));

            orderController = new OrderController(orderRepositoryMock.Object,
                ConfigureMapper.mapper);

            var result = orderController.Checkout();
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<OrderViewModel>(viewResult.Model);
            Assert.Equal(3, viewModel.OrderDetails.Count);
        }

        [Fact]
        public void Checkout_BasketItemCountLessThanOne_RedirectsToHome_Test()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(m => m.RetrieveOrderDetails(It.IsAny<Order>()));

            orderController = new OrderController(orderRepositoryMock.Object,
                ConfigureMapper.mapper);

            var result = orderController.Checkout();
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Product", redirect.ControllerName);
        }

        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
