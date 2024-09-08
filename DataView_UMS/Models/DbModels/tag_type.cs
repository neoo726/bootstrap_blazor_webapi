using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class tag_type
    {
           public tag_type(){


           }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>      
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int tag_type_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tag_type_name {get;set;}

         public string address_format { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int tag_type_category {get;set;}

    }
}
