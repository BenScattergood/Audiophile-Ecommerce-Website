namespace AudiophileEcommerceWebsite.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ZIPCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    
}
