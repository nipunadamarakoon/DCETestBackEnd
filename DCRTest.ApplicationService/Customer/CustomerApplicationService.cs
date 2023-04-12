using DCETest.BussinessObject.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCRTest.ApplicationService.Customer
{
    internal class CustomerApplicationService
    {
      

            public List<Customers> getAllCustomerDetails()
            {
                IDataService dataService = DataServiceBuilder.CreateDataService();
                try
                {
                    ICustomersDataService obj = new CustomersDataService(dataService);
                    return obj.getAllCustomerDetails();

                }
                catch (Exception ex)
                {
                    dataService.Dispose();
                    throw ex;
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
                catch (Exception ex)
                {
                    dataService.Dispose();
                    throw ex;
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
                catch (Exception ex)
                {
                    dataService.Dispose();
                    throw ex;
                }
                finally
                {
                    dataService.Dispose();
                }
            }

        }
    
}
