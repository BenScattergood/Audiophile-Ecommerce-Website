using System.Text.Json.Serialization;

namespace AudiophileEcommerceWebsite.Entities
{
    public class RelatedData
    {
        public int RelatedDataId { get; set; }
        public string Slug { get; set; } = default!;
        public string Name { get; set; } = default!;
        [JsonIgnore]
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
