using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataView_UMS.Models.HttpModels
{
    public class RosStatus
    {
        [Display(Name = "操作台ID")]
        [JsonProperty("rosId")]
        public int RosID { get; set; }
        [Display(Name = "操作台名称")]
        [JsonProperty("rosName")]
        public string RosName { get; set; }
        [JsonProperty("rosTypeId")]
        public int RosTypeId { get; set; }
        [Display(Name = "操作台类型")]
        [JsonProperty("rosTypeName")]
        public string RosTypeName { get; set; }
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("nickName")]
        public string NickName { get; set; }
        [JsonProperty("logoutAllow")]
        public bool LogoutAllow { get; set; }
        [JsonProperty("loginAllow")]
        public bool LoginAllow { get; set; }
        [JsonProperty("loginTime")]
        public DateTime? LoginTime { get; set; }
        public RosStatus(ros r,user u)
        {
            this.RosID = r.ros_id;
            this.RosName = r.ros_name;
            this.UserId = u.user_id;
            this.UserName = u.user_name;
            this.NickName = u.nick_name;
            this.LogoutAllow = r.logout_allow;
            this.LoginAllow = r.login_allow;
            this.LoginTime = r.login_time;
        }
        public RosStatus() { }
    }
    public class RosType
    {
        [Display(Name = "类型ID")]
        [JsonProperty("rosTypeId")]
        public int RosTypeId { get; set; }
        [Display(Name = "类型名称")]
        [JsonProperty("rosTypeName")]
        public string RosTypeName { get; set; }

        public RosType(ros_type r)
        {
            this.RosTypeId = r.ros_type_id;
            this.RosTypeName = r.ros_type_name;
        }
        public RosType() { }
    }
    public class UserLog
    {
        [Display(Name = "记录ID")]
        [JsonProperty("logId")]
        public int LogId { get; set; }
        [Display(Name = "操作台名称")]
        [JsonProperty("rosName")]
        public string RosName { get; set; }
        [Display(Name = "用户名")]
        [JsonProperty("rosTypeName")]
        public string UserName { get; set; }
        [Display(Name = "登录类型")]
        [JsonProperty("rosTypeName")]
        public string LoginType { get; set; }
        [Display(Name = "登录时间")]
        [JsonProperty("rosTypeName")]
        public string LoginTime { get; set; }
        [Display(Name = "登出类型")]
        [JsonProperty("rosTypeName")]
        public string LogoutType { get; set; }
        [Display(Name = "登出时间")]
        [JsonProperty("rosTypeName")]
        public string LogoutTime { get; set; }
      
        public UserLog() { }
    }
}
