using System;
using System.Linq;
using System.Text;
using SqlSugar;
namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class crane_type
    {
           public crane_type(){


           }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int crane_type_id {get;set;}

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
       
        public string crane_type_name {get;set;}
        public string crane_name_format { get; set; }

        public string crane_local_mode_image_url { get; set; }
        public string crane_remote_mode_image_url { get; set; }
    }
}
