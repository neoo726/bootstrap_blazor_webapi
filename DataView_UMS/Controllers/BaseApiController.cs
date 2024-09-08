using DataView_UMS.Utlis;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.Protocols;
using System.Net;

namespace DataView_UMS.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Success<T>(T data, string msg = "Success")
        {
            var response = new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Msg = msg,
                Data = data
            };
            return Ok(response);
        }

        protected IActionResult Success()
        {
            var response = new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Msg = "Success",
                Data = null
            };
            return Ok(response);
        }

        protected IActionResult Error(string msg, int code = StatusCodes.Status500InternalServerError)
        {
            var response = new ApiResponse
            {
                Code = code,
                Msg = msg,
                Data = null
            };
            return StatusCode(code, response);
        }

        protected IActionResult Error<T>(T errorCode) where T : Enum
        {
            string errorMessage = Enum.GetName(typeof(T), errorCode);
            int errorIntCode = EnumHelper.GetEnumIntValue<T>(errorCode);
            var response = new ApiResponse
            {
                Code = errorIntCode,
                Msg = errorMessage,
                Data = null
            };
            return StatusCode(errorIntCode, response);
        }
    }
    public class ApiResponse
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}