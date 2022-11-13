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
                .SingleOrDefault(item => item.ShoppingBasketId == ShoppingBasketId
                && item.Product.ProductId == product.ProductId);

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
            var shoppingBasketItem =
                _audiophileDbContext.ShoppingBasketItems
                .SingleOrDefault(item => item.ShoppingBasketId == ShoppingBasketId
                && item.Product.ProductId == product.ProductId);

            if (shoppingBasketItem.Quantity == 1)
            {
                _audiophileDbContext.ShoppingBasketItems.Remove(shoppingBasketItem);
            }
            else
            {
                shoppingBasketItem.Quantity--;
            }

            _audiophileDbContext.SaveChanges();
        }

        public void ClearBasket()
        {
            var items = _audiophileDbContext.ShoppingBasketItems
                .Where(i => i.ShoppingBasketId == ShoppingBasketId)
                .ToList();

            _audiophileDbContext.RemoveRange(items);
            _audiophileDbContext.SaveChanges();
        }

        public List<ShoppingBasketItem> GetShoppingBasketItems()
        {
            return _audiophileDbContext.ShoppingBasketItems
                .Where(item => item.ShoppingBasketId == ShoppingBasketId)
                .Include(item => item.Product)
                .ToList();
        }

        public decimal GetShoppingBasketTotal()
        {
            return _audiophileDbContext.ShoppingBasketItems
                .Where(s => s.ShoppingBasketId == ShoppingBasketId)
                .Sum(s => s.Product.Price * s.Quantity);
        }
    }
}
