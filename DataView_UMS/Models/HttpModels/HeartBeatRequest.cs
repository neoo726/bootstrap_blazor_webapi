using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Models.HttpModels
{
    public class HeartBeatRequest
    {
        public string UiStation { get; set; }
        public bool LoginAllow { get; set; }
        public bool LogoutAllow { get; set; }
    }
}
