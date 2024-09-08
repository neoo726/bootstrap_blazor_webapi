using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class ums_config
    {
           public ums_config(){


           }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string language {get;set;}
        public string local_user { get; set; }
        public string local_pwd { get; set; }
        /// <summary>
        /// Desc:1=宽松模式，2=严格模式
        /// Default:
        /// Nullable:True
        /// </summary>           
         public int login_priority {get;set;}
           
           public int heartbeat_timeout { get; set; }
            public bool logout_need_pwd { get; set; }
            public bool cross_login_enable { get; set; }
            public string comm_info { get; set; }
    }
}
