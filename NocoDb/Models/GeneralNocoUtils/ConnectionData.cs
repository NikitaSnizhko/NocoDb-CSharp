using System;
using Newtonsoft.Json;

namespace NocoDb.Models.GeneralNocoUtils
{
    public class ConnectionData
    {
        [JsonProperty("host")]
        public string Host { get; set; }
        
        [JsonProperty("port")]
        public string Port { get; set; }
        
        [JsonProperty("user")]
        public string User { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("database")]
        public string Database { get; set; } = string.Empty;
    }
}