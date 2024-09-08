using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataView_UMS;
using DataView_UMS.Models;
using DataView_UMS.Models.ConfigModels;

namespace DataView_UMS.Utlis
{
    internal class ConfigHelper
    {
        public static string Language { get; set; }
        public static Enums.LoginPriorityType LoginPriority { get; set; } = Enums.LoginPriorityType.LastLoginPriority;
        public static bool CrossLoginEnable { get; set; }=false;
        public static bool LogoutNeedPwd { get; set; } = false;
        public static int HeartbeatTimeout { get; set; } = 60000;
        public static Models.ConfigModels.CommInfo CommInfo { get; set; }
        /// <summary>
        /// 初始化配置项
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void InitConfiguration()
        {
            
            CommInfo = new Models.ConfigModels.CommInfo();
            var configInfo=DbHelper.GetDbInstance().Queryable<ums_config>().First();
            if (configInfo == null)
            {
                throw new Exception("configuration info not found!");
            }
            Language=configInfo.language;
            LoginPriority = EnumHelper.ConvertToEnum< Enums.LoginPriorityType>(configInfo.login_priority.ToString());
            CrossLoginEnable = configInfo.cross_login_enable;
            LogoutNeedPwd = configInfo.logout_need_pwd;
            HeartbeatTimeout = configInfo.heartbeat_timeout;
            try
            {
                if (string.IsNullOrEmpty(configInfo.comm_info))
                {
                    CommInfo = new Models.ConfigModels.CommInfo()
                    {
                         CommType="rest",
                    };
                }
                else
                {
                    CommInfo = JsonConvert.DeserializeObject<Models.ConfigModels.CommInfo>(configInfo.comm_info);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 更新登录策略
        /// </summary>
        /// <param name="loginPriority"></param>
        /// <param name="crossLoginEnable"></param>
        /// <param name="logoutNeedPwd"></param>
        /// <param name="heartbeatTimeout"></param>
        public static void UpdateLoginStrategy(int loginPriority, bool crossLoginEnable, bool logoutNeedPwd, int heartbeatTimeout)
        {
            ConfigHelper.LoginPriority=(Enums.LoginPriorityType)loginPriority;
            ConfigHelper.CrossLoginEnable = crossLoginEnable;
            ConfigHelper.LogoutNeedPwd = logoutNeedPwd;
            ConfigHelper.HeartbeatTimeout = heartbeatTimeout;
            var configInfo = DbHelper.GetDbInstance().Queryable<ums_config>().First();
            configInfo.login_priority = (byte)loginPriority;
            configInfo.cross_login_enable = crossLoginEnable;
            configInfo.logout_need_pwd = logoutNeedPwd;
            configInfo.heartbeat_timeout = heartbeatTimeout;
            DbHelper.GetDbInstance().Updateable<ums_config>(configInfo).ExecuteCommand();
        }
        /// <summary>
        /// 更新通讯配置
        /// </summary>
        /// <param name="commInfo"></param>
        public static void UpdateCommInfo(CommInfo commInfo)
        {
            ConfigHelper.CommInfo = commInfo;
           
            var configInfo = DbHelper.GetDbInstance().Queryable<ums_config>().First();
            configInfo.comm_info= JsonConvert.SerializeObject(commInfo);
            
            DbHelper.GetDbInstance().Updateable<ums_config>(configInfo).ExecuteCommand();
        }
    }
}
