using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataView_UMS.Models.HttpModels
{
    public class RosInfo
    {
        [JsonProperty("rosId")]
        public int RosID { get; set; }
        [JsonProperty("rosName")]
        public string RosName { get; set; }
        [JsonProperty("rosTypeId")]
        public int RosTypeId { get; set; } =1;
    }
    public class UserInfo
    {
        [Display(Name = "用户Id")]
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [Display(Name = "用户名")]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [Display(Name = "昵称")]
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        [Display(Name = "密码")]
        [JsonProperty("password")]
        public string Password { get; set; }
        [Display(Name = "角色Id")]
        [JsonProperty("roleId")]
        public int RoleId { get; set; }
        [Display(Name = "角色名称")]
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
        //[Display(Name = "类型ID")]
        //[JsonProperty("enable")]
        //public bool Enable { get; set; } = true;
    }
    public class RoleInfo
    {
        [Display(Name = "角色ID")]
        [JsonProperty("roleId")]
        public long RoleId { get; set; }
        [Display(Name = "角色名称")]
        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        

        //[Display(Name = "类型ID")]
        //[JsonProperty("enable")]
        //public bool Enable { get; set; } = true;
    }
    internal class CommInfo
    {
        [JsonProperty("rosId")]
        public int RosID { get; set; }
        [JsonProperty("rosName")]
        public string RosName { get; set; }
        [JsonProperty("userId")]
        public long UesrId { get; set; }
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
        public CommInfo(ros r,user u)
        {
            this.RosID = r.ros_id;
            this.RosName = r.ros_name;
            this.UesrId = u.user_id;
            this.UserName = u.user_name;
            this.NickName = u.nick_name;
            this.LogoutAllow = r.logout_allow;
            this.LoginAllow = r.login_allow;
            this.LoginTime = r.login_time;
        }
    }
}
