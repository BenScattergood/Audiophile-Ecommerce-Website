namespace AudiophileEcommerceWebsite.ViewModels
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AudiophileDbContext _audiophileDbContext;
        private readonly IShoppingBasket shoppingBasket;
        private readonly IMapper mapper;

        public OrderRepository(AudiophileDbContext audiophileDbContext,
            IShoppingBasket shoppingBasket, IMapper mapper)
        {
            this._audiophileDbContext = audiophileDbContext;
            this.shoppingBasket = shoppingBasket;
            this.mapper = mapper;
        }

        public void GetOrderSummary(Order order)
        {
            order.OrderProductTotal = shoppingBasket.GetShoppingBasketTotal();
            var shoppingBasketItems = shoppingBasket.GetShoppingBasketItems();
            foreach (var item in shoppingBasketItems)
            {
                var orderDetail = mapper.Map<OrderDetail>(item);
                orderDetail.Price = item.Product.Price * item.Quantity;
                order.OrderDetails.Add(orderDetail);
            }
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            
            _audiophileDbContext.Orders.Add(order);

            _audiophileDbContext.SaveChanges();
        }
    }
}
