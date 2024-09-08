using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class crane
    {
           public crane(){


           }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
       
        public int crane_id {get;set;}

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        
        public int crane_type_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string crane_ip {get;set;}

           /// <summary>
           /// Desc:设备状态显示
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool crane_status_show {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string crane_name {get;set;}
        public string crane_desc { get; set; }
        public bool bind_permit { get; set; }
        public bool control_onoff { get; set; }
        public bool local_remote { get; set; }
        public string crane_status_config { get; set; }
    }
}
