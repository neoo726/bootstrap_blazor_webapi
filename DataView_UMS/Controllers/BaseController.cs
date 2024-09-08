//using DataView_UMS.Utlis;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

//namespace DataView_UMS.Controllers
//{
//    public class BaseApiController : ControllerBase
//    {

//        protected IHttpActionResult Success<T>(T data, string msg = "Success")
//        {
//            var response = new ApiResponse
//            {
//                Code = 200,
//                Msg = msg,
//                Data = data
//            };
//            return Ok(response);
//        }
//        protected IHttpActionResult Success()
//        {
//            var response = new ApiResponse
//            {
//                Code = 200,
//                Msg = "Success",
//                Data = null
//            };
//            return Ok(response);
//        }
//        protected IHttpActionResult Error(string msg, int code = 500)
//        {
//            var response = new ApiResponse
//            {
//                Code = code,
//                Msg = msg,
//                Data = null
//            };
//            return Content(System.Net.HttpStatusCode.OK, response);
//        }
      
//        protected IHttpActionResult Error<T>(T errorCode) where T : Enum
//        {
//            string errorMessage = EnumHelper.GetEnumDescription(errorCode);
//            int errorIntCode = (int)EnumHelper.GetEnumIntValue<T>(errorCode);
//            var response = new ApiResponse
//            {
//                Code = errorIntCode,
//                Msg = errorMessage,
//                Data = null
//            };
//            return Content(System.Net.HttpStatusCode.OK, response);
//        }
//        public class ApiResponse
//        {
//            public int Code { get; set; }
//            public string Msg { get; set; }
//            public object Data { get; set; }

//        }
//    }
    
//}
