using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace DataView_UMS.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class return_value
    {
           public return_value(){


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
           public string return_code {get;set;}

          
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string desc_zh {get;set;}
           public string desc_en { get; set; }
    }
}
