using Newtonsoft.Json;

namespace NocoDb.Models.GeneralNocoUtils.Request
{
    public class TestDbConnectionRequest
    {
        [JsonProperty("client")]
        public string Client { get; set; }
        
        [JsonProperty("connection")]
        public ConnectionData Connection { get; set; }
    }
}