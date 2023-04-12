using DCETest.BussinessObject.Customer;
using DCETest.DataAccessService.Customer;
using DCETest.DataAccessService.Customer.Interface;
using DCETest.DataAccessService.SqlDataService;

namespace DCETest.ApplicationService.Customer
{
    public class CustomerApplicationService
    {
        public List<Customers> getAllCustomerDetails()
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                ICustomersDataService obj = new CustomersDataService(dataService);
                return obj.getAllCustomerDetails();

            }
            catch (Exception)
            {
                dataService.Dispose();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

        public bool addNewCustomer(Customers customer)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                ICustomersDataService obj = new CustomersDataService(dataService);
                return obj.addNewCustomer(customer);
            }
            catch (Exception)
            {
                dataService.Dispose();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

        public bool updateCustomer(Customers customer)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                ICustomersDataService obj = new CustomersDataService(dataService);
                return obj.updateCustomer(customer);
            }
            catch (Exception)
            {
                dataService.Dispose();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

        public bool deleteCustomerDetails(Guid Userid)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                ICustomersDataService obj = new CustomersDataService(dataService);
                return obj.deleteCustomerDetails(Userid);
            }
            catch (Exception)
            {
                dataService.Dispose();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }

        }
    }
}
