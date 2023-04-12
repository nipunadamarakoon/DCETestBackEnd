using DCETest.ApplicationService.Customer;
using DCETest.BackEndService.Base;
using DCETest.BussinessObject.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DCETest.BackEndService.Base.BaseResponce;

namespace DCETest.BackEndService.Controllers.Customer
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //get all customers
        [HttpGet]
        public APIResponce getAllCustomerDetails()
        {
            BaseResponce baseObj = new BaseResponce();
            try
            {
                CustomerApplicationService obj = new CustomerApplicationService();
                var result = obj.getAllCustomerDetails();
                return baseObj.GenerateSucessResponce(result);
            }
            catch (Exception ex)
            {
                return baseObj.GenerateExceptionMessage(ex);
            }
        }

        //Add New Customer Detail
        [HttpPost]
        public APIResponce addNewCustomer([FromBody] Customers customers)
        {
            BaseResponce baseObj = new BaseResponce();
            try
            {
                CustomerApplicationService obj = new CustomerApplicationService();
                var result = obj.addNewCustomer(customers);
                return baseObj.GenerateSucessResponce(result);
            }
            catch (Exception ex)
            {
                return baseObj.GenerateExceptionMessage(ex);
            }
        }

        //update Customer Detail
        [HttpPost]
        public APIResponce updateCustomer([FromBody] Customers customers)
        {
            BaseResponce baseObj = new BaseResponce();
            try
            {
                CustomerApplicationService obj = new CustomerApplicationService();
                var result = obj.updateCustomer(customers);
                return baseObj.GenerateSucessResponce(result);
            }
            catch (Exception ex)
            {
                return baseObj.GenerateExceptionMessage(ex);
            }
        }

        //delete customer by Id
        [HttpGet]
        public APIResponce deleteCustomerDetails(Guid Userid)
        {
            BaseResponce baseObj = new BaseResponce();
            try
            {
                CustomerApplicationService obj = new CustomerApplicationService();
                var result = obj.deleteCustomerDetails(Userid);
                return baseObj.GenerateSucessResponce(result);
            }
            catch (Exception ex)
            {
                return baseObj.GenerateExceptionMessage(ex);
            }
        }
    }
}
