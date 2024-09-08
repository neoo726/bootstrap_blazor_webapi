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
    public class SettingResult
    {
        public bool IsOperateSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; } = null;

        public static SettingResult Success<T>(T data)
        {
            return new SettingResult { IsOperateSuccess = true , ErrorCode =200,Data= data };
        }
        public static SettingResult Success() 
        {
            return new SettingResult { IsOperateSuccess = true, ErrorCode = 200};
        }
        public static SettingResult Failure(int errorCode, string errorMessage)
        {
            return new SettingResult
            {
                IsOperateSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
        
    }
    internal class SettingService
    {
        /// <summary>
        /// 批量添加ros
        /// </summary>
        /// <returns></returns>
        public async Task<SettingResult> AddRosBatch(List<ros> rosLst)
        {
            var existedRos=DbHelper.GetDbInstance().Queryable<ros>().ToList();
            var finallyAddRosList = new List<ros>();
            foreach (var ros in rosLst)
            {
                if (existedRos.Exists(r => r.ros_name == ros.ros_name))
                {
                    //ros已存在
                    continue;
                }
                finallyAddRosList.Add(ros);
            }
            if (finallyAddRosList.Count == 0)
            {
                return SettingResult.Failure((int)HttpStatusCode.BadRequest, "All Ros already exist");
            }
            var rosStatusLst = await Task.Run(() =>
            {
                return DbHelper.GetDbInstance().Insertable<ros>(finallyAddRosList).ExecuteCommand();
            });
            if (rosStatusLst == 0)
            {
                return SettingResult.Failure((int)HttpStatusCode.BadRequest, "Failed inserting to database!");

            }
            return SettingResult.Success();
        }
        /// <summary>
        /// 添加user
        /// </summary>
        /// <returns></returns>
        public async Task<SettingResult> AddUser(user newUser)
        {
           var existResult=await DbHelper.GetDbInstance().Queryable<user>()
                .AnyAsync(x=>x.user_name==newUser.user_name);
            if (existResult)
            {
                return SettingResult.Failure((int)HttpStatusCode.BadRequest, "User already exisit!");
            }
            var biggestUserId=await DbHelper.GetDbInstance().Queryable<user>()
                .MaxAsync(x=>x.user_id);
            newUser.user_id=biggestUserId+1;
            var userAddResult = await Task.Run(() =>
            {
                return DbHelper.GetDbInstance().Insertable<user>(newUser).ExecuteCommand();
            });
            if (userAddResult == 0)
            {
                return SettingResult.Failure((int)HttpStatusCode.BadRequest, "Failed inserting to database!");

            }
            return SettingResult.Success();
        }
        /// <summary>
        /// 更新登录策略
        /// </summary>
        /// <param name="loginPriority"></param>
        /// <param name="crossLoginEnable"></param>
        /// <param name="logoutNeedPwd"></param>
        /// <param name="heartbeatTimeout"></param>
        /// <returns></returns>
        public async Task<SettingResult> UpdateLoginStrategy(int loginPriority,bool crossLoginEnable,bool logoutNeedPwd,int heartbeatTimeout)
        {
            await Task.Run(() =>
            {
                ConfigHelper.UpdateLoginStrategy(loginPriority, crossLoginEnable, logoutNeedPwd, heartbeatTimeout);
            });
            return SettingResult.Success();
        }
        /// <summary>
        /// 更新通讯信息
        /// </summary>
        /// <param name="commInfo"></param>
        /// <returns></returns>
        public async Task<SettingResult> UpdateCommInfo(Models.ConfigModels.CommInfo commInfo)
        {
            await Task.Run(() =>
            {
                ConfigHelper.UpdateCommInfo(commInfo);
            });
            return SettingResult.Success();
        }
    }
}
