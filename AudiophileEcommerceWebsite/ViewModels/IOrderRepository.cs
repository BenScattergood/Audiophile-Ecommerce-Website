namespace AudiophileEcommerceWebsite.ViewModels
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public void RetrieveOrderDetails(Order order);
        public void ProcessOrder(Order order);
    }
}
