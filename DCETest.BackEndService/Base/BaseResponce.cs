using System.Net;

namespace DCETest.BackEndService.Base
{
    //CoummonResponce
    public class BaseResponce
    {
        public BaseResponce() { }
        public class APIResponce
        {
            public HttpStatusCode statusCode { get; set; }
            public object result { get; set; }
            public Exception error { get; set; }
        }
       
        public APIResponce GenerateSucessResponce(object result)
        {
            APIResponce obj = new APIResponce();                  
            obj.statusCode = HttpStatusCode.OK;           
            obj.result = result;                                         
            return obj;
        }
        public APIResponce GenerateExceptionMessage(Exception ex)
        {
            APIResponce obj = new APIResponce();
            obj.statusCode = HttpStatusCode.BadRequest;
            obj.error = ex;               
            return obj;
        }
        
    }
}
