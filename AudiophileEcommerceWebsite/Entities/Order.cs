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
        public decimal Shipping => 50;
        public decimal VAT => Math.Round(OrderProductTotal * (decimal)0.2, 2);
        public decimal OrderProductTotal { get; set; }
        public decimal OrderGrandTotal => OrderProductTotal + VAT + Shipping;
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }

    
}
