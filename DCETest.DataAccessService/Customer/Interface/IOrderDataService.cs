using DCETest.BussinessObject.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCETest.DataAccessService.Customer.Interface
{
    public interface IOrderDataService
    {
        List<OrderByCustomer> activeOrderByCustomer(Guid custid);
    }
}
