namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IShoppingBasket
    {
        void AddToBasket(Product product, int quantity);
        List<ShoppingBasketItem> GetShoppingBasketItems();
        void RemoveFromBasket(Product product);
        void ClearBasket();
    }
}
