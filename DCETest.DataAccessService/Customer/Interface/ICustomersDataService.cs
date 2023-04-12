using DCETest.BussinessObject.Customer;

namespace DCETest.DataAccessService.Customer.Interface
{
    public interface ICustomersDataService
    {
        List<Customers> getAllCustomerDetails();
        bool addNewCustomer(Customers customer);
        bool updateCustomer(Customers customer);
        bool deleteCustomerDetails(Guid Userid);
    }
}
