namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IOrderRepository
    {
        public Task CreateOrder(Order order);
        public void RetrieveOrderDetails(Order order);
        public Task ProcessOrder(Order order);

        public Order GetOrder(int orderId);
    }
}
