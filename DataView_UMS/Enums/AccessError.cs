using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Enums
{
    // 错误码枚举
    /// <summary>
    /// 错误码
    /// </summary>
    public enum AccessErrorCode
    {
        /// <summary>
        /// 用户id不存在
        /// </summary>
        UserIdNotExist = 1002029001,

        /// <summary>
        /// 应用id不存在
        /// </summary>
        AppIdNotExist = 1002029002,

        /// <summary>
        /// 应用密钥不存在
        /// </summary>
        AppSecretNotExist = 1002029003,

        /// <summary>
        /// 操作台号不存在
        /// </summary>
        UiStationNotExist = 1002029004,

        /// <summary>
        /// 应用id错误
        /// </summary>
        AppIdError = 1002029005,

        /// <summary>
        /// 客户端密钥错误
        /// </summary>
        ClientSecretError = 1002029006,

        /// <summary>
        /// 客户端已禁用
        /// </summary>
        ClientDisabled = 1002029007
    }
}
