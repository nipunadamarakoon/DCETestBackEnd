using DCETest.ApplicationService.Order;
using DCETest.BackEndService.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DCETest.BackEndService.Base.BaseResponce;

namespace DCETest.BackEndService.Controllers.Order
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase 
    {
        //Get Active Orders by Customer Id
        [HttpGet]
        public APIResponce activeOrderByCustomer(Guid custid)
        {
            BaseResponce baseObj = new BaseResponce();
            try
            {
                OrderApplicationService obj = new OrderApplicationService();
                var result = obj.activeOrderByCustomer(custid);              
                return baseObj.GenerateSucessResponce(result);
            }
            catch(Exception ex) 
            {
                return baseObj.GenerateExceptionMessage(ex);
            }
            
        }
    }
}
