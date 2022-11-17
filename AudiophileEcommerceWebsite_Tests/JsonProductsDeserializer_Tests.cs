namespace AudiophileEcommerceWebsite_Tests
{
    public class JsonProductsDeserializer_Tests : 
        IClassFixture<JsonProductsDeserializerFixture>
    {
        private JsonProductsDeserializerFixture _productsFixture;

        public JsonProductsDeserializer_Tests(JsonProductsDeserializerFixture
            jsonProductsDeserializerFixture)
        {
            _productsFixture = jsonProductsDeserializerFixture;
        }

        [Fact]
        public void DeserializeJson_ProductsContains6Items_Test()
        {   
            Assert.True(_productsFixture.Products.Count() == 6);
        }

        [Fact]
        public void DeserializeJson_ProductsMembersArePopulated_Test()
        {
            var testData = new List<object[]>
            {
                new object[] { "yx1-earphones", _productsFixture.Products[0].Slug },
                new object[] { "XX59 Headphones", _productsFixture.Products[1].ProductName },
                new object[] { "/assets/product-yx1-earphones/tablet/image-product.jpg", _productsFixture.Products[0].Image.Tablet },
                new object[] { "earphones", _productsFixture.Products[0].Category.CategoryName },
                new object[] { false, _productsFixture.Products[2].isNew },
                new object[] { 1750, _productsFixture.Products[2].Price },
                new object[] { "As the gold standard for headphones, the classic XX99 Mark I offers detailed and accurate audio reproduction for audiophiles, mixing engineers, and music aficionados alike in studios and on the go.", _productsFixture.Products[2].Description},
                new object[] { "As the headphones all others are measured against, the XX99 Mark I demonstrates over five decades of audio expertise, redefining the critical listening experience. This pair of closed-back headphones are made of industrial, aerospace-grade materials to emphasize durability at a relatively light weight of 11 oz.\n\nFrom the handcrafted microfiber ear cushions to the robust metal headband with inner damping element, the components work together to deliver comfort and uncompromising sound. Its closed-back design delivers up to 27 dB of passive noise cancellation, reducing resonance by reflecting sound to a dedicated absorber. For connectivity, a specially tuned cable is includes with a balanced gold connector.", _productsFixture.Products[2].Features },
                new object[] { 4, _productsFixture.Products[2].Accessories.Count() },
                new object[] { "/assets/product-xx99-mark-two-headphones/tablet/image-gallery-2.jpg", _productsFixture.Products[3].Gallery.Second.Tablet },
                new object[] { "ZX7 Speaker", _productsFixture.Products[5].RelatedData[0].Name },
                new object[] { "/assets/shared/mobile/image-xx99-mark-one-headphones.jpg", _productsFixture.Products[5].RelatedData[1].Images.Mobile},
            };

            foreach (var item in testData)
            {
                Assert.Equal(item[0], item[1]);
            }
            
        }
    }
}