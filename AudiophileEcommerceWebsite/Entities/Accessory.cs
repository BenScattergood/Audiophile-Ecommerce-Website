namespace AudiophileEcommerceWebsite.Entities
{
    public class Accessory
    {
        public int AccessoryId { get; set; }
        public int Quantity { get; set; }
        public string Item { get; set; } = default!;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
