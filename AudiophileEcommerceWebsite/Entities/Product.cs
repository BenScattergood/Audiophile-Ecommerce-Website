using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AudiophileEcommerceWebsite.Entities
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int ProductId { get; set; }
        public string Slug { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string ProductName { get; set; } = default!;
        [JsonIgnore]
        public Image Image { get; set; } = default!;
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; } = default!;
        [JsonIgnore]
        public Image CategoryImages { get; set; } = default!;
        public bool isNew { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = default!;
        public string Features { get; set; } = default!;
        [JsonIgnore]
        public List<Accessory> Accessories { get; set; } = new List<Accessory>();
        [JsonIgnore]
        public Gallery? Gallery { get; set; }
        [JsonIgnore]
        public List<RelatedData> RelatedData { get; set; } = new List<RelatedData>();
    }
}
