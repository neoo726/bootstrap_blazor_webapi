using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using DataView_UMS;
using DataView_UMS.Enums;
using DataView_UMS.Models;
using DataView_UMS.Models.HttpModels;
using DataView_UMS.Utlis;

namespace DataView_UMS.Services
{
    public class UserManageResult
    {
        public bool IsOperateSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; } = null;

        public static UserManageResult Success<T>(T data) where T: TokenData
        {
            return new UserManageResult { IsOperateSuccess = true , ErrorCode =200,Data= data };
        }
        public static UserManageResult Success() 
        {
            return new UserManageResult { IsOperateSuccess = true, ErrorCode = 200};
        }
        public static UserManageResult Failure(int errorCode, string errorMessage)
        {
            return new UserManageResult
            {
                IsOperateSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
        public static UserManageResult Failure<T>(T errorCode) where T : Enum
        {
            string errorMessage = EnumHelper.GetEnumDescription(errorCode);
            int errorIntCode = (int)EnumHelper.GetEnumIntValue<T>(errorCode);
            return new UserManageResult
            {
                IsOperateSuccess = false,
                ErrorCode = errorIntCode,
                ErrorMessage = errorMessage ?? "Unknown error",
            };
        }
    }
    internal class UserService
    {
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        public async Task<UserManageResult> AccountUserLogin(string username,string uiStation)
        {
            var user=DbHelper.GetDbInstance().Queryable<Models.user>()
                .Where(x=>x.user_name==username).First();
            var ros =DbHelper.GetDbInstance().Queryable<Models.ros>()
                .Where(x=>x.ros_name==uiStation).First();
            //检查是否有其他用户在线
            var anotherUserLog = DbHelper.GetDbInstance().Queryable<Models.user_log>()
                .Where(x => x.user_id == ros.user_id && x.user_id != user.user_id&& x.logout_time == DateTime.MinValue).First();
         
            DbHelper.GetDbInstance().BeginTran();
            var loginTime = DateTime.UtcNow;
            ros.user_id = user.user_id;
            ros.login_time = loginTime;
            ros.access_token= Guid.NewGuid().ToString();
            ros.last_heartbeat_time = loginTime;
            
            var userLog = new Models.user_log()
            {
                user_id = user.user_id,
                login_time = loginTime,
                ros_id = ros.ros_id,
                ros_type_id=ros.ros_type_id,
                login_type=(int)Enums.LoginType.AccountLogin,
            };
            try
            {
                DbHelper.GetDbInstance().Updateable<ros>(ros)
                .Where(x => x.ros_name == uiStation).ExecuteCommand();
                if (anotherUserLog != null)
                {
                    anotherUserLog.logout_time = loginTime;
                    anotherUserLog.logout_type = (int)Enums.LogoutType.AccountLogout;
                    DbHelper.GetDbInstance().Updateable<user_log>(anotherUserLog).ExecuteCommand();
                }
                DbHelper.GetDbInstance().Insertable<user_log>(userLog);
                DbHelper.GetDbInstance().CommitTran();
            }
            catch (Exception ex)
            {
                throw;
            }
            //记录登录缓存，用于检测心跳
            CacheService.UpdateClientHeartBeat(uiStation,ros.access_token);
            return UserManageResult.Success();
        }
        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="username"></param>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        public async Task<UserManageResult> AccountUserLogout(string token)
        {
            //清除ros表中token
            var ros = DbHelper.GetDbInstance().Queryable<Models.ros>()
                .Where(x => x.access_token == token).First();
            if (ros == null)
            {
                return UserManageResult.Failure(ClientErrorCode.InvalidToken);
            }
            DbHelper.GetDbInstance().BeginTran();
            try
            {
                //更新user_log中的logout_time
                var loginLog = DbHelper.GetDbInstance().Queryable<Models.user_log>()
                    .Where(x => x.ros_id == ros.ros_id).First();
                loginLog.logout_time = DateTime.UtcNow;
                loginLog.logout_type=(int)Enums.LogoutType.AccountLogout;
                DbHelper.GetDbInstance().Updateable<user_log>(loginLog).ExecuteCommand();
                ros.user_id = null;
                ros.login_time=DateTime.MinValue;
                ros.access_token=string.Empty;
                ros.last_heartbeat_time=DateTime.MinValue;
                DbHelper.GetDbInstance().Updateable<ros>(ros).ExecuteCommand();
                DbHelper.GetDbInstance().CommitTran();
            }
            catch (Exception ex)
            {
                throw;
            }
            //记录登录缓存，用于检测心跳
            CacheService.UpdateClientHeartBeat(ros.ros_name, null);
            return UserManageResult.Success();
        }

        public async Task<UserManageResult> GetLoginUser(string uiStation)
        {
            var ros = DbHelper.GetDbInstance().Queryable<Models.ros>()
                .Where(x => x.ros_name.ToLower() == uiStation.ToLower()).First();
            if (ros == null)
            {
                return UserManageResult.Failure(ClientErrorCode.IllegalClient);
            }
            if (string.IsNullOrEmpty(ros.access_token))
            {
                return UserManageResult.Failure(ClientErrorCode.NoLoginInfoForConsole);
            }
            var user = DbHelper.GetDbInstance().Queryable<Models.user>()
                .Where(x => x.user_id == ros.user_id).First();
            var userInfo = new Models.HttpModels.TokenData()
            {
                UserId = Convert.ToInt32(user.user_id),
                Username = user.user_name,
                Nickname = user.nick_name,
            };
            return UserManageResult.Success(userInfo);
        }
    }
}
