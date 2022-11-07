namespace AudiophileEcommerceWebsite.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public int FirstId { get; set; }
        public Image First { get; set; } = default!;
        public int SecondId { get; set; }
        public Image Second { get; set; } = default!;
        public int ThirdId { get; set; }
        public Image Third { get; set; } = default!;
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
