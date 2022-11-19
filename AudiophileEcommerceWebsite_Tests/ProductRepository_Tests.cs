

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests
{
    [Collection("sequential")]
    public class ProductRepository_Tests : 
        IClassFixture<ProductRepositoryFixture>
    {
        private ProductRepository productRepository;
        private List<Category> categories;

        public ProductRepository_Tests(
            ProductRepositoryFixture productRepositoryFixture)
        {
            this.productRepository = productRepositoryFixture.productRepository;
            this.categories = productRepositoryFixture.categories;
        }
        [Fact]
        public void GetAllProducts_ReturnsAllProducts_Test()
        {
            Assert.Equal(6, productRepository.GetAllProducts().Count());
        }

        [Fact]
        public void GetProductsFromCategory_ReturnsCorrectProducts_Test()
        {
            var products = productRepository.GetProductsFromCategory(categories[0].CategoryName);
            Assert.Single(products);
        }

        [Fact]
        public void GetProductsFromCategory_CanAccessCategoryImages_Test()
        {
            var product = productRepository.GetProductsFromCategory(categories[1].CategoryName)[0].CategoryImages.Desktop;
            Assert.NotNull(product);
        }
        
        [Fact]
        public void GetProductById_ReturnsCorrectProduct_Test()
        {
            var product = productRepository.GetProductById(2);
            Assert.Equal("xx59-headphones", product.Slug);
        }

        [Fact]
        public void GetProductById_CanAccessRelatedDataImages_Test()
        {
            var product = productRepository.GetProductById(2).RelatedData[0].Images.Desktop;
            Assert.NotNull(product);
        }

        [Fact]
        public void ProvideProductIdToRelatedDataVM_Test()
        {
            //return to
        }

        [Fact]
        public void ReturnShallowProductFromName_ReturnsCorrectProduct_Test()
        {
            var productName = "XX99 Mark II Headphones";
            var product = productRepository.ReturnShallowProductFromName(productName);
            Assert.Equal(2999, product.Price);
        }
    }
}
