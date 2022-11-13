namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public void GetOrderSummary(Order order);
    }
}
