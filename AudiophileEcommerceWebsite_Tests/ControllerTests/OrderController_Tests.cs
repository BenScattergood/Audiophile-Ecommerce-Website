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
        public OrderController orderControllerWithCallback;
        public OrderController orderControllerWithoutCallback;
        public AudiophileDbContext dbContext;
        public string idString;
        public List<OrderDetail> orderDetails;
        public OrderViewModel orderViewModel;

        public OrderController_Tests(
            OrderControllerFixture orderControllerFixture)
        {
            products = orderControllerFixture.products;
            orderControllerWithCallback = orderControllerFixture.orderControllerWithCallback;
            orderControllerWithoutCallback = orderControllerFixture.orderControllerWithoutCallback;
            dbContext = orderControllerFixture.dbContext;
            idString = orderControllerFixture.idString;
            orderDetails = orderControllerFixture.orderDetails;
            orderViewModel = orderControllerFixture.orderViewModel;
        }

        [Fact]
        public void Checkout_BasketItemCountMoreThanOne_ReturnsView_Test()
        {
            var result = orderControllerWithCallback.Checkout();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<OrderViewModel>(viewResult.Model);
            Assert.Equal(3, viewModel.OrderDetails.Count);
        }

        [Fact]
        public void Checkout_BasketItemCountLessThanOne_RedirectsToHome_Test()
        {
            var result = orderControllerWithoutCallback.Checkout();

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Product", redirect.ControllerName);
        }

        [Fact]
        public void CheckoutPost_BasketItemCountLessThanOne_ReturnsView_Test()
        {
            var result = orderControllerWithoutCallback.Checkout(orderViewModel);

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Product", redirect.ControllerName);
        }

        [Fact]
        public void CheckoutPost_ModelStateInvalid_ReturnsView_Test()
        {
            orderControllerWithCallback.ModelState.AddModelError("fake error", "this is an error");
            var result = orderControllerWithCallback.Checkout(orderViewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<OrderViewModel>(viewResult.Model);
            Assert.Equal(3, viewModel.OrderDetails.Count);
        }

        [Fact]
        public void CheckoutPost_ModelStateValid_RedirectsToCheckoutComplete_Test()
        {
            orderControllerWithCallback.ModelState.AddModelError("fake error", "this is an error");
            var result = orderControllerWithCallback.Checkout(orderViewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<OrderViewModel>(viewResult.Model);
            Assert.Equal(3, viewModel.OrderDetails.Count); 
        }

        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
