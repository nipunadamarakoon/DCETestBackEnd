namespace DCETest.BussinessObject.Order
{
    public class OrderByCustomer
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string SupplierName { get; set; }
        public string OrderBy { get; set; }
        public string OrderedOn { get; set; }
        public string ShippedOn { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderType OrderType { get; set; }
        public string Email { get; set; }
             
    }

    public enum OrderStatus
    {
        Pending,
        processing,
        Delivered,
        Reject,
        Cancel
    }

    public enum OrderType
    {
        High,
        Medium,
        Low

    }
}
