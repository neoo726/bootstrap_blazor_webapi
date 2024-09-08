using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataView_UMS;
using DataView_UMS.Models;
using DataView_UMS.Utlis;

namespace DataView_UMS.Services
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public static AuthenticationResult Success()
        {
            return new AuthenticationResult { IsAuthenticated = true , ErrorCode =200};
        }

        public static AuthenticationResult Failure<T>(T errorCode) where T:Enum
        {
            string errorMessage = EnumHelper.GetEnumDescription(errorCode);
            int errorIntCode = (int)EnumHelper.GetEnumIntValue<T>(errorCode);
            return new AuthenticationResult
            {
                IsAuthenticated = false,
                ErrorCode = errorIntCode,
                ErrorMessage = errorMessage?? "Unknown error",
            };
        }
    }
    internal class AuthenticationService
    {
        
        /// <summary>
        /// 校验用户名密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthenticationResult> CheckUserAndPwdAsync(string username, string password)
        {
            if (DbHelper.GetDbInstance() == null)
            {
                throw new Exception("DbHelper.GetDbInstance() is null");
            }
            var valiUserResult = DbHelper.GetDbInstance()
                .Queryable<Models.user>()
                .Any(x => x.user_name.ToLower() == Base64.DecodeBase64(username).ToLower() && x.user_pwd == Base64.DecodeBase64(password));
            ;
            if (!await Task.FromResult(valiUserResult))
            {
                return AuthenticationResult.Failure(Enums.ClientErrorCode.UsernameOrPasswordIncorrect);
            }               
            return AuthenticationResult.Success();
        }
        /// <summary>
        /// 校验客户端
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthenticationResult> CheckClientAsync(string uiStation)
        {         
            if (DbHelper.GetDbInstance() == null)
            {
                throw new Exception("DbHelper.GetDbInstance() is null");
            }
            
            var validClientResult = DbHelper.GetDbInstance()
                .Queryable<Models.ros>()
                .Any(x => x.ros_name == uiStation);
            if (!await Task.FromResult(validClientResult))
            {
                return AuthenticationResult.Failure(Enums.ClientErrorCode.IllegalClient);
            }                 
            return AuthenticationResult.Success();
        }
        /// <summary>
        /// 校验登录状态
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthenticationResult> CheckLoginStatusAsync(string username, string password, string uiStation)
        {
            if (DbHelper.GetDbInstance() == null)
            {
                throw new Exception("DbHelper.GetDbInstance() is null");
            }            
            var isLoggedIn = await IsUserLoggedInAsync(username);
            if (isLoggedIn)
            {
                //判断跨台登录策略
                if (!ConfigHelper.CrossLoginEnable)
                {
                    //不允许跨台登录
                    return AuthenticationResult.Failure(Enums.ClientErrorCode.UserAlreadyOnline);
                }
                else
                {
                    //允许跨台登录
                    Utlis.CacheService.AddClientEvent(uiStation, true);//添加客户端登出事件
                    return AuthenticationResult.Failure(Enums.ClientErrorCode.UserLoggedInElsewhere);
                }

            }
            var isClientLoggedIn = await IsClientLoggedInAsync(uiStation);
            if (isClientLoggedIn)
            {
                //判断登录优先策略
                if(ConfigHelper.LoginPriority== Enums.LoginPriorityType.FirstLoginPriority)
                {
                    //先登录优先
                    return AuthenticationResult.Failure(Enums.ClientErrorCode.DuplicateLogin);
                }
                else
                {
                    //后登录优先
                    return AuthenticationResult.Success();
                }
            }
            return AuthenticationResult.Success();
        }
        /// <summary>
        /// 检查客户端登录状态
        /// </summary>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthenticationResult> CheckClientStatusAsync(string uiStation)
        {
            if (DbHelper.GetDbInstance() == null)
            {
                throw new Exception("DbHelper.GetDbInstance() is null");
            }
            var isClientLoggedIn = await IsClientLoggedInAsync(uiStation);
            if (!isClientLoggedIn)
            {
                return AuthenticationResult.Failure(Enums.ClientErrorCode.NoLoginInfoForConsole);
            }
            return AuthenticationResult.Success();
        }
        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthenticationResult> CheckTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return AuthenticationResult.Failure(Enums.ClientErrorCode.TokenMissing);
            }
            if (DbHelper.GetDbInstance() == null)
            {
                throw new Exception("DbHelper.GetDbInstance() is null");
            }
            var validTokenResult = DbHelper.GetDbInstance()
                .Queryable<Models.ros>()
                .Any(x => x.access_token == token);
            ;
            if (!await Task.FromResult(validTokenResult))
            {
                return AuthenticationResult.Failure(Enums.ClientErrorCode.InvalidToken);
            }
            return AuthenticationResult.Success();
        }
        private Task<bool> IsUserLoggedInAsync(string username)
        {
            var user = DbHelper.GetDbInstance()
              .Queryable<user>()
              .First(x => x.user_name == Base64.DecodeBase64(username));
            
            var isLoggedInResult = DbHelper.GetDbInstance()
             .Queryable<ros>()
             .AnyAsync(x=> x.user_id == user.user_id);
            return isLoggedInResult;
        }
        private Task<bool> IsClientLoggedInAsync(string uiStation)
        {
            // 简化的检查客户端是否已登录的逻辑
            var isLoggedInResult = DbHelper.GetDbInstance()
              .Queryable<Models.ros>()
              .AnyAsync(x => x.ros_name == uiStation);
            return isLoggedInResult; 
        }
    }
}
