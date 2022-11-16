using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Fixtures
{
    public class JsonProductsDeserializerFixture : IDisposable
    {
        public List<Product> Products { get; }

        public JsonProductsDeserializerFixture()
        {
            Products = JsonProductsDeserializer
                .DeserializeJson("Entities/SeedData/data.json");
        }

        public void Dispose()
        {
            //clean up not required
        }
    }
}
