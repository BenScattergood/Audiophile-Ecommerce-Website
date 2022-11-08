using Microsoft.AspNetCore.Http;


namespace AudiophileEcommerceWebsite.ViewModels
{
    public class ShoppingBasket : IShoppingBasket
    {
        private readonly AudiophileDbContext _audiophileDbContext;
        public string? ShoppingBasketId { get; set; }

        public ShoppingBasket(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            this._audiophileDbContext = services.GetService<AudiophileDbContext>() ?? throw new Exception("Error initializing");

            string basketId = session?.GetString("BasketId") ?? Guid.NewGuid().ToString();

            session?.SetString("BasketId", basketId);

            ShoppingBasketId = basketId;
        }

        public void AddToBasket(Product product, int quantity)
        {
            var shoppingBasketItem =
                _audiophileDbContext.ShoppingBasketItems
                .Where(item => item.ShoppingBasketId == ShoppingBasketId)
                .SingleOrDefault(item => item.Product.ProductId == product.ProductId);

            if (shoppingBasketItem is null)
            {
                _audiophileDbContext.ShoppingBasketItems.Add(new ShoppingBasketItem
                {
                    ShoppingBasketId = ShoppingBasketId,
                    Quantity = quantity,
                    Product = product,
                });
            }
            else
            {
                shoppingBasketItem.Quantity += quantity;
            }

            _audiophileDbContext.SaveChanges();
        }

        public void RemoveFromBasket(Product product)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingBasketItem> GetShoppingBasketItems()
        {
            return _audiophileDbContext.ShoppingBasketItems
                .Where(item => item.ShoppingBasketId == ShoppingBasketId)
                .Include(item => item.Product)
                .OrderBy(item => item.Quantity)
                .ToList();
        }
    }
}
