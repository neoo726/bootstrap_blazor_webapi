using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Models.HttpModels
{
    public class LoginResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("data")]
        public TokenData Data { get; set; }
    }
    public class TokenData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
