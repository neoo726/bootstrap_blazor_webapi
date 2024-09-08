using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class user_log
    {
           public user_log(){


           }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ros_id {get;set;}
        public int ros_type_id { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long user_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           //public byte login_or_logout {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           //public DateTime log_time {get;set;}

           /// <summary>
           /// Desc:1=账号密码登录，2=access登录
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte login_type {get;set;}
            public byte logout_type { get; set; }
             public  DateTime login_time { get; set; }
           public DateTime? logout_time { get; set; }
    }
}
