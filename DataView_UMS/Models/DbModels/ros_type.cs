using System;
using System.Linq;
using System.Text;
using SqlSugar;
namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class ros_type
    {
        public ros_type(){


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ros_type_id {get;set;}

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
      
        public string ros_type_name {get;set;}
        public string ros_name_format { get; set; }
        public string ros_online_image_url { get; set; }
        public string ros_offline_image_url { get; set; }
        public string support_crane_type { get; set; }
        public bool cross_ros_login_enable { get; set; }
    }
}
