using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Models.ConfigModels
{
    public class CommInfo
    {
        [JsonProperty("commType")]
        public string CommType { get; set;  }
        [JsonProperty("accessRestServerIp")]
        public string AccessRestServerIp { get; set; }
        [JsonProperty("accessRestServerPort")]
        public int AccessRestServerPort { get; set; }
        [JsonProperty("rabbitmqServerIp")]
        public string RabbitMQServerIp { get; set; }
        [JsonProperty("rabbitmqServerPort")]
        public int RabbitMQServerPort { get; set; }
        [JsonProperty("rabbitmqServerUserName")]
        public string RabbitMQServerUsername { get; set; }
        [JsonProperty("rabbitmqServerPassword")]
        public string RabbitMQServerPassword { get; set; }
        [JsonProperty("rabbitmqFanoutExchangeName")]
        public string RabbitMQFanoutExchangeName { get; set; }
        [JsonProperty("rabbitmqRpcExchangeName")]
        public string RabbitMQRPCExchangeName { get; set; }
        [JsonProperty("rabbitmqRpcQueueName")]

        public string RabbitMQRPCQueueName { get; set; }
        [JsonProperty("tcpPort")]
        public string TCPPort { get; set; }

    }
}
