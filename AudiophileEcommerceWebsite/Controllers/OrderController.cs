using AudiophileEcommerceWebsite.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace AudiophileEcommerceWebsite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderController(IOrderRepository orderRepository,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var order = new Order();
            //get current details perhaps
            orderRepository.RetrieveOrderDetails(order);
            if (order.OrderDetails.Count() < 1)
            {
                //this won't be available to user
                return RedirectToAction("Index", "Product");
            }
            var orderViewModel = mapper.Map<OrderViewModel>(order);
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(OrderViewModel orderViewModel)
        {
            //take payment
            var order = mapper.Map<Order>(orderViewModel);
            orderRepository.RetrieveOrderDetails(order);

            if (order.OrderDetails.Count() < 1)
            {
                return RedirectToAction("Index","Product");
            }

            if (!ModelState.IsValid)
            {
                orderViewModel = mapper.Map<OrderViewModel>(order);
                return View(orderViewModel);
            }

            orderRepository.CreateOrder(order);

            return RedirectToAction("CheckoutComplete", order);
        }

        public IActionResult CheckoutComplete(Order order)
        {
            orderRepository.RetrieveOrderDetails(order);
            var orderViewModel = mapper.Map<OrderViewModel>(order);
            //
            return View(orderViewModel);
        }
    }
}
