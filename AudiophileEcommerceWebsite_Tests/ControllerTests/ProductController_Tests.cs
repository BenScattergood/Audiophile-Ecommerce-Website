using AudiophileEcommerceWebsite.Controllers;
using AudiophileEcommerceWebsite.Entities.SeedData;
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
    public class ProductController_Tests : 
        IClassFixture<ProductControllerFixture>, IDisposable
    {
        private List<Product> products;
        private List<Category> categories;
        private ProductController productController;
        public ProductController_Tests(ProductControllerFixture productControllerFixture)
        {
            products = productControllerFixture.products;
            categories = productControllerFixture.categories;
            productController = productControllerFixture.productController;
        }

        [Fact]
        public void Index_ReturnsCorrectViewModel_Test()
        {
            var result = productController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModelList = Assert.IsType<List<ProductViewModel>>(viewResult.Model);
            Assert.Equal("XX99 Mark I Headphones", viewModelList[2].Name);
        }

        [Fact]
        public void Category_ReturnsCorrectCategory_Test()
        {
            var result = productController.Category(categories[0].ToString());

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModelList = Assert.IsType<List<ProductViewModel>>(viewResult.Model);
            Assert.Equal(3, viewModelList.Count);
        }

        //[Fact]
        //public void Product_ReturnsCorrectViewModel_Test()
        //{
        //    var result = productController.Product(1);

        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var viewModel = Assert.IsType<ProductViewModel>(viewResult.Model);

        //    Assert.Equal("xx59-headphones", viewModel.Slug);
        //}

        public void Dispose()
        {
            DatabaseConnection.ResetDb();
        }
    }
}
