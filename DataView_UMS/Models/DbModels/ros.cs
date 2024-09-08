using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class ros
    {
        public ros(){


        }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
      
        public int ros_id {get;set;}

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
       
        public int ros_type_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ros_name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string role_right {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte? bypass {get;set;}

           /// <summary>
           /// Desc:登录是否与PLC交互
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool login_plc_enable {get;set;}

           /// <summary>
           /// Desc:绑定是否与PLC交互
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool bind_plc_enable {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? user_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? login_time {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int crane_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? bind_time {get;set;}

           /// <summary>
           /// Desc:支持的设备类型
           /// Default:
           /// Nullable:True
           /// </summary>           
          // public int? support_crane_type_id {get;set;}
        public int crane_type_id { get; set; }
        public string ros_desc { get; set; }
        public bool  bind_permit { get; set; }
        public string access_token { get; set; }
        public DateTime last_heartbeat_time { get; set; }
        public bool login_allow { get; set; }
        public bool logout_allow { get; set; }
    }
}
