using DCETest.BussinessObject.Customer;
using DCETest.DataAccessService.Customer.Interface;
using DCETest.DataAccessService.SqlDataService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCETest.DataAccessService.Customer
{
    public class CustomersDataService: ICustomersDataService
    {
        IDataService dataService;

        public CustomersDataService(IDataService _dataService)
        {
            dataService = _dataService;
        }

        public List<Customers> getAllCustomerDetails()
        {
            try
            {
                List<Customers> custDtl = new List<Customers>();
                DbDataReader reader = dataService.ExecuteReader("[DCTest].[GetAllCustomers]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        custDtl.Add(new Customers
                        {
                            Userid = dataReader.GetGuid("UserId"),
                            Username = dataReader.GetString("Username"),
                            Email = dataReader.GetString("Email"),
                            FirstName = dataReader.GetString("FirstName"),                            
                            LastName = dataReader.GetString("LastName"),
                            CreateOn = dataReader.GetDateTime("CreateOn"),
                            IsActive = dataReader.GetBoolean("IsActive"),

                        });
                    }
                    reader.Close();
                }

                return custDtl;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool addNewCustomer(Customers customer)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[5];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@username", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.Username);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@emai", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.Email);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@fname", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.FirstName);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@lname", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.LastName);
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@isactive", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, customer.IsActive);

                DbDataReader reader = dataService.ExecuteReader("[DCTest].[AddNewCustomer]", arrSqlParam);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool updateCustomer(Customers customer)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[6];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@username", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.Username);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@emai", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.Email);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@fname", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.FirstName);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@lname", System.Data.DbType.String, System.Data.ParameterDirection.Input, customer.LastName);
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@isactive", System.Data.DbType.Boolean, System.Data.ParameterDirection.Input, customer.IsActive);
                arrSqlParam[5] = DataServiceBuilder.CreateDBParameter("@userId", System.Data.DbType.Guid, System.Data.ParameterDirection.Input, customer.Userid);

                DbDataReader reader = dataService.ExecuteReader("[DCTest].[UpdateCustomer]", arrSqlParam);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deleteCustomerDetails(Guid Userid)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@userId", System.Data.DbType.Guid, System.Data.ParameterDirection.Input, Userid);

                DbDataReader reader = dataService.ExecuteReader("[DCTest].[DeleteCustomer]", arrSqlParam);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
