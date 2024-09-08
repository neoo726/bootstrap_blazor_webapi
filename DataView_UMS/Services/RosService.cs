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
    public class RosResult
    {
        public bool IsOperateSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; } = null;

        public static RosResult Success<T>(T data)
        {
            return new RosResult { IsOperateSuccess = true , ErrorCode =200,Data= data };
        }
        public static RosResult Success() 
        {
            return new RosResult { IsOperateSuccess = true, ErrorCode = 200};
        }
        public static RosResult Failure(int errorCode, string errorMessage)
        {
            return new RosResult
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
    internal class RosService
    {
        /// <summary>
        /// 获取所有操作台状态列表
        /// </summary>
        /// <returns></returns>
        public async Task<RosResult> GetAllRosStatus()
        {
            if (DbHelper.GetDbInstance() == null)
            {
                throw new Exception("DbHelper.GetDbInstance() is null");
            }
            var rosStatusLst = await Task.Run(() =>
            {
                var rosLst = DbHelper.GetDbInstance().Queryable<Models.ros>()
                .LeftJoin<Models.user>((r, u) => r.user_id == u.user_id)
                .Select((r, u) => new RosStatus
                {
                    RosID = r.ros_id,
                    RosName = r.ros_name,
                    UserName = u.user_name,
                    NickName=u.nick_name,
                    UserId=u.user_id,
                    LoginTime=r.login_time,
                    
                }).ToList();
                return rosLst;
            });
            
            return RosResult.Success<List<RosStatus>>(rosStatusLst);
        }
    }
}
