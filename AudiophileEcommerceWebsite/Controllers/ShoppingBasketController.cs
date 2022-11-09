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

        public RedirectToActionResult UpdateShoppingBasketItemHome(int quantity, string pieName)
        {
            if (quantity > 0)
            {
                return RedirectToAction("AddToShoppingBasket", new
                {
                    quantity = quantity,
                    pieName = pieName
                });
            }

            return RedirectToAction("DecrementFromShoppingBasket",new
            {
                quantity = quantity,
                pieName = pieName
            });
        }

        public RedirectToActionResult AddToShoppingBasket(int quantity, string pieName)
        {
            var product = productRepository.ReturnShallowProductFromName(pieName);
            shoppingBasket.AddToBasket(product, quantity);

            return RedirectToAction("Index");
            //redirect to index
        }

        public RedirectToActionResult DecrementFromShoppingBasket(int quantity, string pieName)
        {
            var product = productRepository.ReturnShallowProductFromName(pieName);
            shoppingBasket.RemoveFromBasket(product);

            return RedirectToAction("Index");
            //redirect to index
        }

        public RedirectToActionResult ClearBasket()
        {
            shoppingBasket.ClearBasket();
            return RedirectToAction("Index");
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
