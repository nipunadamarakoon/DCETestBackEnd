namespace DCETest.BussinessObject.Customer
{
    public class Customers
    {
        public Guid? Userid { get; set; } = null;
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreateOn { get; set; } = null;
        public bool IsActive { get; set; }
    }
}
