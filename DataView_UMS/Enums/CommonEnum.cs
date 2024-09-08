using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Enums
{
    public enum LoginType
    {
        AccessLogin = 1,
        AccountLogin = 2,

    }
    public enum LogoutType
    {
        AccessLogout = 1,
        AccountLogout = 2,
        AutoLogoutByTimeout = 3,
        ForceLogout = 4,
    }
    public enum LoginPriorityType
    {
        FirstLoginPriority=1,
        LastLoginPriority=2,
    }
}
