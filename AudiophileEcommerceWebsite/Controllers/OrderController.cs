using AudiophileEcommerceWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AudiophileEcommerceWebsite.Controllers
{
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
            orderRepository.GetOrderSummary(order);
            if (order.OrderDetails.Count() < 1)
            {
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
            orderRepository.GetOrderSummary(order);

            if (order.OrderDetails.Count() < 1)
            {
                return View(order);
            }

            if (!ModelState.IsValid)
            {
                orderViewModel = mapper.Map<OrderViewModel>(order);
                return View(orderViewModel);
            }

            orderRepository.CreateOrder(order);

            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}
