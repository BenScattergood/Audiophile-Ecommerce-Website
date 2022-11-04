using AudiophileEcommerceWebsite.Entities;

namespace AudiophileEcommerceWebsite.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool isNew { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
    }
}
