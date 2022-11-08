using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite.Components
{
    public class ShoppingBasketSummary : ViewComponent
    {
        private readonly IShoppingBasket shoppingBasket;
        private readonly IMapper mapper;

        public ShoppingBasketSummary(IShoppingBasket shoppingBasket,
            IMapper mapper)
        {
            this.shoppingBasket = shoppingBasket;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingBasket.GetShoppingBasketItems();

            var viewModel = mapper.Map<List<ShoppingBasketItemViewModel>>(items);
            return View(viewModel);
        }
    }
}
