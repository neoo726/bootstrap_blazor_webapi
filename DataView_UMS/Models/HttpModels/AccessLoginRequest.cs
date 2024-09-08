using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Models.HttpModels
{
    /// <summary>
    /// 登录请求参数
    /// </summary>
    public class AccessLoginRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [JsonProperty("userId")]
        public long UserId { get; set; }

        /// <summary>
        /// 应用id（base64加密）
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 应用密钥（base64加密）
        /// </summary>
        [JsonProperty("app_secret")]
        public string AppSecret { get; set; }

        /// <summary>
        /// 操作台号
        /// </summary>
        [JsonProperty("ui_station")]
        public string UiStation { get; set; }
    }
}
