using AudiophileEcommerceWebsite.Services;
using AudiophileEcommerceWebsite.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace AudiophileEcommerceWebsite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IValidateOrder _validateOrder;

        public OrderController(IOrderRepository orderRepository,
            IMapper mapper,
            IValidateOrder validateOrder)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            _validateOrder = validateOrder;
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
        public async Task<IActionResult> Checkout(OrderViewModel orderViewModel)
        {
            var order = mapper.Map<Order>(orderViewModel);
            orderRepository.RetrieveOrderDetails(order);
            if (!ModelState.IsValid)
            {
                var orderVm = mapper.Map<OrderViewModel>(order);
                return View(orderVm);
            }

            if (order.OrderDetails.Count() < 1)
            {
                return RedirectToAction("Index","Product");
            }

            await orderRepository.ProcessOrder(order);

            return RedirectToAction("CheckoutComplete", new {orderId = order.OrderId});
        }

        public async Task<IActionResult> CheckoutComplete(int orderId)
        {
            if ((await _validateOrder.IsValid(orderId)) == false)
            {
                return RedirectToAction("Index","Product");
            }
            
            var order = orderRepository.GetOrder(orderId);
            var orderViewModel = mapper.Map<OrderViewModel>(order);

            return View(orderViewModel);
        }
    }
}
