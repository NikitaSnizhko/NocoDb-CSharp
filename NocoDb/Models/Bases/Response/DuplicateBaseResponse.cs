using Newtonsoft.Json;

namespace NocoDb.Models.Bases.Response;

public class DuplicateBaseResponse
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("base_id")]
    public string BaseId { get; set; }
}