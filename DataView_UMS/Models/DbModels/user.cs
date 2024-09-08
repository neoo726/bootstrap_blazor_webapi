using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class user
    {
           public user(){


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
           public long user_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string user_name {get;set;}
            /// <summary>
            /// 
            /// </summary>
          public string nick_name { get; set; }

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int user_role {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime create_date {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string user_pwd {get;set;}
        public string email { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public bool enable {get;set;}

    }
}
