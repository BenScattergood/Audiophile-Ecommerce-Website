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
        [JsonPropertyName("image")]
        public Image? MainImage { get; set; }
        public int CategoryId { get; set; }
        [JsonPropertyName("ignore")]
        public Category Category { get; set; } = default!;
        public Image? CategoryImage { get; set; }
        public bool isNew { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = default!;
        public string Features { get; set; } = default!;
        public List<Details>? Includes { get; set; }
        public Dictionary<string, Image>? Gallery { get; set; }
        public List<Other>? Others { get; set; }
    }

    public class Image
    {
        public int ImageId { get; set; }
        public string? Mobile { get; set; }
        public string? Tablet { get; set; }
        public string? Desktop { get; set; }
    }

    public class Details
    {
        public int DetailsId { get; set; }
        public int Quantity { get; set; }
        public string Item { get; set; } = default!;
    }

    public class Other
    {
        public int OtherId { get; set; }
        public string Slug { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Image? Images { get; set; }
    }
}
