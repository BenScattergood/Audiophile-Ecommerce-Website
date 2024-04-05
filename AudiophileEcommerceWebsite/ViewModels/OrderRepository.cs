using AudiophileEcommerceWebsite.Services;

namespace AudiophileEcommerceWebsite.ViewModels
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AudiophileDbContext _audiophileDbContext;
        private readonly IShoppingBasket shoppingBasket;
        private readonly IMapper mapper;
        private readonly IUserService _userService;

        public OrderRepository(AudiophileDbContext audiophileDbContext,
            IShoppingBasket shoppingBasket, IMapper mapper,
            IUserService userService)
        {
            this._audiophileDbContext = audiophileDbContext;
            this.shoppingBasket = shoppingBasket;
            this.mapper = mapper;
            _userService = userService;
        }

        public void RetrieveOrderDetails(Order order)
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
        public async Task ProcessOrder(Order order)
        {
            using var transaction = _audiophileDbContext.Database.BeginTransaction();

            await CreateOrder(order);
            shoppingBasket.ClearBasket();

            transaction.Commit();
        }

        public Order GetOrder(int orderId) =>
            _audiophileDbContext.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                
                .First(o => o.OrderId == orderId);

        public async Task CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            order.User = await _userService.GetCurrentUser();
            
            _audiophileDbContext.Orders.Add(order);

            _audiophileDbContext.SaveChanges();
        }
    }
}
