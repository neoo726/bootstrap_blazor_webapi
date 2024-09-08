using DataView_UMS.Models.HttpModels;
using DataView_UMS.Services;
using Microsoft.AspNetCore.Mvc;



namespace DataView_UMS.Controllers
{

    //[RoutePrefix("api/auth")]
    [ApiController]
    [Route("api/auth")]

    public class AuthController :  BaseApiController
    {
        private readonly Services.AuthenticationService _authService = new AuthenticationService();
        private readonly UserService _userService=new UserService();
        #region ums&dv交互接口
        [HttpPost]
        [Route("oauth/token")]
        public async  Task<IActionResult> AccountLogin([FromBody]Models.HttpModels.LoginRequest request)
        {
           //校验用户信息合法性
           var authResult =  await _authService.CheckUserAndPwdAsync(request.Username,request.Password);
           if (!authResult.IsAuthenticated)
           {
              return Error(authResult.ErrorMessage,authResult.ErrorCode);
           }
            //校验客户端合法性
            authResult = await _authService.CheckClientAsync(request.UiStation);
            if (!authResult.IsAuthenticated)
            {
                return Error(authResult.ErrorMessage, authResult.ErrorCode);
            }
            //校验用户和客户端的登录状态
            authResult = await _authService.CheckLoginStatusAsync(request.Username, request.Password, request.UiStation);
            if (!authResult.IsAuthenticated)
            {
                return Error(authResult.ErrorMessage, authResult.ErrorCode);
            }
            //修改登录状态为已登录，生成token
            var loginResult = await _userService.AccountUserLogin(request.Username, request.UiStation);
            if (loginResult.IsOperateSuccess)
            {
                return Success();
            }
            else
            {
                return Error(loginResult.ErrorMessage, loginResult.ErrorCode);
            }
        }
        [HttpDelete]
        [Route("auth/token/logout")]
        public async Task<IActionResult> AccountLogout()
        {
            string accessToken=Request.Headers.Authorization.ToString();
            //校验用户信息
            var authResult =await _authService.CheckTokenAsync(accessToken);
            if (!authResult.IsAuthenticated)
            {
                return Error(authResult.ErrorMessage, authResult.ErrorCode);
            }
            //清除token
            var logoutResult = await _userService.AccountUserLogout(accessToken);
            if (logoutResult.IsOperateSuccess)
            {
                return Success(logoutResult.ErrorCode);
            }
            else
            {
                return Error(logoutResult.ErrorMessage, logoutResult.ErrorCode);
            }
        }
        [HttpPost]
        [Route("auth/token/heartBeat")]
        public async Task<IActionResult> HeartBeat([FromBody] Models.HttpModels.HeartBeatRequest request)
        {
            //校验客户端合法性
            var authResult = await _authService.CheckClientAsync(request.UiStation);
            if (!authResult.IsAuthenticated)
            {
                return Error(authResult.ErrorMessage, authResult.ErrorCode);
            }
            //检查客户端的登录状态
            var clientLoginResult = await _authService.CheckClientStatusAsync(request.UiStation);
            if (!clientLoginResult.IsAuthenticated)
            {
                //未登录
                return Error(authResult.ErrorMessage, authResult.ErrorCode);
            }
            //判断是否需要强制登出
            var isForceLogout = Utlis.CacheService.GetClientEvent(request.UiStation);
            if (isForceLogout)
            {
                //重置状态
                Utlis.CacheService.AddClientEvent(request.UiStation, false);
                return Error(Enums.ClientErrorCode.AwaitingLogout);
            }
            //获取登录用户信息
            var loginUser = await _userService.GetLoginUser(request.UiStation);
            return Success<TokenData>((TokenData)loginUser.Data);
        }
        #endregion
        #region ums&第三方门禁交互接口
        [HttpPost]
        [Route("auth/{supplier}/verify")]
        public IActionResult AccessVerify()
        {
            return Success("Hello World!");
        }
        [HttpPost]
        [Route("auth/{supplier}/updateUser")]
        public IActionResult AccessUpdateUser()
        {
            return Success("Hello World!");
        }
        #endregion
    }
}
