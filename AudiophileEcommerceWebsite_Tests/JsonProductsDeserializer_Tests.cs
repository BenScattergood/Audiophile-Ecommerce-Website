namespace AudiophileEcommerceWebsite_Tests
{
    public class JsonProductsDeserializer_Tests : 
        IClassFixture<JsonProductsDeserializerFixture>
    {
        private readonly JsonProductsDeserializerFixture _productsFixture;
        
        public JsonProductsDeserializer_Tests(JsonProductsDeserializerFixture
            jsonProductsDeserializerFixture)
        {
            this._productsFixture = jsonProductsDeserializerFixture;
        }

        [Fact]
        public void DeserializeJson_ProductsContains6Items_Test()
        {   
            Assert.True(_productsFixture.Products.Count() == 6);
        }

        public static IEnumerable<Object[]> JsonProductTestData
        {
            get
            {
                return new List<Object[]>
                {
                    new object[] { _products, "1" }
                };
            }
        }

        [Theory]
        [MemberData(nameof(JsonProductTestData))]
        public void DeserializeJson_Product(string actual,
            string expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}