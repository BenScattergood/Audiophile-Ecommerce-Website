using AudiophileEcommerceWebsite.Entities;
using System.Text.Json.Serialization;

namespace AudiophileEcommerceWebsite.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public Category Category { get; set; }
        public Image CategoryImages { get; set; }
        public bool isNew { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public List<Accessory> Accessories { get; set; }
        public Gallery? Gallery { get; set; }
        public List<RelatedData> RelatedData { get; set; }
    }
}
