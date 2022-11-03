namespace AudiophileEcommerceWebsite.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public List<Image> First { get; set; } = new List<Image>();
        public List<Image> Second { get; set; } = new List<Image>();
        public List<Image> Third { get; set; } = new List<Image>();
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
