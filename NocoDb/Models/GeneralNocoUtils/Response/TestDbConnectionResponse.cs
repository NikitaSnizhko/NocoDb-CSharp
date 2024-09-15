using Newtonsoft.Json;

namespace NocoDb.Models.GeneralNocoUtils.Response
{
    public class TestDbConnectionResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}