using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite.Entities.SeedData;
using AudiophileEcommerceWebsite_Tests.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures.ControllerFixtures
{
    public class OrderControllerFixture : IDisposable
    {
        public List<Product> products;
        public OrderController orderController;
        public AudiophileDbContext dbContext;
        public string idString;
        public List<OrderDetail> orderDetails;
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
        }
        public void Dispose()
        {
            //nr
        }
    }
}
