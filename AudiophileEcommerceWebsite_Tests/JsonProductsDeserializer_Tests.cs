using AudiophileEcommerceWebsite.Entities;

namespace AudiophileEcommerceWebsite_Tests
{
    public class JsonProductsDeserializer_Tests
    {
        [Fact]
        public void Test1()
        {
            var genresList = new Category[]
                {
                        new Category { CategoryName = "headphones" },
                        new Category { CategoryName = "earphones" },
                        new Category { CategoryName = "speakers" },
                };
        }
    }
}