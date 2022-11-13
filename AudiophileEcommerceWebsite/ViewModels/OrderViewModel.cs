namespace AudiophileEcommerceWebsite.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ZIPCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public decimal Shipping { get; set; }
        public decimal VAT {get; set; }
        public decimal OrderProductTotal { get; set; }
        public decimal OrderGrandTotal { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? eMoneyNumber { get; set; }
        public string? eMoneyPIN { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }

    public enum PaymentMethod
    {
        eMoney,
        cash,
    }
}
