namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IShoppingBasket
    {
        void AddToBasket(Product product, int quantity);
        void RemoveFromBasket(Product product);
        List<ShoppingBasketItem> GetShoppingBasketItems();
    }
}
