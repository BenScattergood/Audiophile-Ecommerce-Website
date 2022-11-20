namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public void UpdateOrderDetails(Order order);
    }
}
