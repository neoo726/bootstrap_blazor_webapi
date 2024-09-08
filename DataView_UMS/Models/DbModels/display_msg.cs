using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class display_msg
    {
           public display_msg(){


           }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int msg_id {get;set;}

           /// <summary>
           /// Desc:1=业务逻辑信息，2=系统状态变更信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? msg_type {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? msg_time {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string msg {get;set;}

    }
}
