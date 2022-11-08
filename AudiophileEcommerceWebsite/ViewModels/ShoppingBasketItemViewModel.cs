namespace AudiophileEcommerceWebsite.ViewModels
{
    public class ShoppingBasketItemViewModel
    {
        public int ShoppingBasketItemId { get; set; }
        public ProductViewModel Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
