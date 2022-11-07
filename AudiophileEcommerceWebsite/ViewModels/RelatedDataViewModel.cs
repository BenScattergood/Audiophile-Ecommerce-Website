using System.Text.Json.Serialization;

namespace AudiophileEcommerceWebsite.ViewModels
{
	public class RelatedDataViewModel
	{
        public int RelatedDataId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int ImagesId { get; set; }
        public Image Images { get; set; }
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
    }
}
