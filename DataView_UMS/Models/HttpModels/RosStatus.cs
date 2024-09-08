using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataView_UMS.Models.HttpModels
{
    public class RosStatus
    {
        [JsonProperty("rosId")]
        public int RosID { get; set; }
        [JsonProperty("rosName")]
        public string RosName { get; set; }
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
}
