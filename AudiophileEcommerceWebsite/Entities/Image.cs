using System.ComponentModel.DataAnnotations.Schema;

namespace AudiophileEcommerceWebsite.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string? Mobile { get; set; }
        public string? Tablet { get; set; }
        public string? Desktop { get; set; }
        public List<Gallery> FirstGalleries { get; set; } = new List<Gallery>();
        public List<Gallery> SecondGalleries { get; set; } = new List<Gallery>();
        public List<Gallery> ThirdGalleries { get; set; } = new List<Gallery>();
        public int? ProductImageId { get; set; }
        public Product? Product { get; set; }
        public int? CategoryProductId { get; set; }
        public Product? CategoryProduct { get; set; }
        public List<RelatedData> RelatedData { get; set; } = new List<RelatedData>();
    }
}
