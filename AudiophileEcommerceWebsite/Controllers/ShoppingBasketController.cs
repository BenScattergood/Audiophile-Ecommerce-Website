namespace AudiophileEcommerceWebsite.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasket shoppingBasket;
        private readonly IProductRepository productRepository;

        public ShoppingBasketController(IShoppingBasket shoppingBasket,
            IProductRepository productRepository)
        {
            this.shoppingBasket = shoppingBasket;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return ViewComponent("ShoppingBasketSummary");
        }

        public RedirectToActionResult AddToShoppingBasket(int quantity, string pieName)
        {
            var product = productRepository.ReturnShallowProductFromName(pieName);
            shoppingBasket.AddToBasket(product, quantity);

            return RedirectToAction("Index");
            //redirect to index
        }

        //public RedirectToActionResult RemoveFromShoppingBasket(int pieId)
        //{
        //    //redirect to index
        //}

        //public RedirectToActionResult ClearBasket()
        //{
        //    //redirect to index
        //}
    }
}
