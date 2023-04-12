using DCETest.BussinessObject.Customer;
using DCETest.BussinessObject.Order;
using DCETest.DataAccessService.Customer.Interface;
using DCETest.DataAccessService.SqlDataService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCETest.DataAccessService.Order
{
    public class OrderDataService: IOrderDataService
    {
        IDataService dataService;

        public OrderDataService(IDataService _dataService)
        {
            dataService = _dataService;
        }

        public List<OrderByCustomer> activeOrderByCustomer(Guid custid)
        {
            try
            {
                List<OrderByCustomer> orderDtl = new List<OrderByCustomer>();

                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@custID", System.Data.DbType.Guid, System.Data.ParameterDirection.Input, custid);

                DbDataReader reader = dataService.ExecuteReader("[DCTest].[GetOrderByCustomer]", arrSqlParam);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        orderDtl.Add(new OrderByCustomer
                        {
                            OrderId = dataReader.GetGuid("OrderId"),
                            ProductId = dataReader.GetGuid("ProductId"),
                            ProductName = dataReader.GetString("ProductName"),
                            UnitPrice = dataReader.GetDecimal("UnitPrice"),
                            SupplierName = dataReader.GetString("SupplierName"),
                            OrderBy = dataReader.GetString("Username"),
                            OrderedOn = dataReader.GetDateTime("OrderedOn").ToString("yyyy-MM-dd HH:mm:ss"),
                            ShippedOn = dataReader.GetDateTime("ShipedOn").ToString("yyyy-MM-dd HH:mm:ss"),
                            OrderStatus = (OrderStatus)dataReader.GetInt32("OrderStatus"),
                            OrderType = (OrderType)dataReader.GetInt32("OrderType"),
                            Email = dataReader.GetString("Email"),

                        });
                    }
                    reader.Close();
                }

                return orderDtl;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
