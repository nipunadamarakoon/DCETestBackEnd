using DCETest.BussinessObject.Customer;
using DCETest.BussinessObject.Order;
using DCETest.DataAccessService.Customer.Interface;
using DCETest.DataAccessService.Customer;
using DCETest.DataAccessService.SqlDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCETest.DataAccessService.Order;

namespace DCETest.ApplicationService.Order
{
    public class OrderApplicationService
    {
        public List<OrderByCustomer> activeOrderByCustomer(Guid custid)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IOrderDataService obj = new OrderDataService(dataService);
                return obj.activeOrderByCustomer(custid);

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
