using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Utlis
{
    public  class CacheService
    {
        /// <summary>
        /// 客户端事件缓存,key=uistation,value=是否触发强制登出
        /// </summary>
        public static ConcurrentDictionary<string, bool> ClientEventDic = new ConcurrentDictionary<string, bool>();
        /// <summary>
        /// 客户端心跳缓存,key=uistation,value=token+时间戳
        /// </summary>
        public static ConcurrentDictionary<string, TokenHeartBeat> ClientHeartBeatDic = new ConcurrentDictionary<string, TokenHeartBeat>();
        public static void AddClientEvent(string uistation, bool forceLogout)
        {
            ClientEventDic.AddOrUpdate(uistation, forceLogout, (key, oldValue) => forceLogout);
        }
        public static bool GetClientEvent(string uistation)
        {
            ClientEventDic.TryGetValue(uistation, out bool forceLogout);
            return forceLogout;
        }
        /// <summary>
        /// 更新客户端心跳缓存
        /// </summary>
        /// <param name="uiStation"></param>
        public static void UpdateClientHeartBeat(string uiStation, string token)
        {

            var tokenData = new TokenHeartBeat
            {
                Token = token,
                LastHeartBeat = DateTime.UtcNow
            };
            ClientHeartBeatDic.AddOrUpdate(uiStation, tokenData, (key, oldValue) => tokenData);
        }
        /// <summary>
        /// 获取客户端心跳缓存
        /// </summary>
        /// <param name="uiStation"></param>
        /// <returns></returns>
        public static DateTime GetClientHeartBeat(string uiStation)
        {
            ClientHeartBeatDic.TryGetValue(uiStation, out TokenHeartBeat lastHeartBeat);
            return lastHeartBeat.LastHeartBeat;
        }
    }
    public class TokenHeartBeat
    {
        public string Token { get; set; }
        public DateTime LastHeartBeat { get; set; }
    }
}
