namespace AudiophileEcommerceWebsite.Entities
{
    public class ShoppingBasketItem
    {
        public int ShoppingBasketItemId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public string? ShoppingBasketId { get; set; }
    }
}
