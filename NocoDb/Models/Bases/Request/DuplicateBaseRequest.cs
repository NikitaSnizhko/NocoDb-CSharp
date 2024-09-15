using Newtonsoft.Json;

namespace NocoDb.Models.Bases.Request;

public class DuplicateBaseRequest
{
    [JsonProperty("excludeData")]
    public bool ExcludeData { get; set; }
    
    [JsonProperty("excludeViews")]
    public bool ExcludeViews { get; set; }
    
    [JsonProperty("excludeHooks")]
    public bool ExcludeHooks { get; set; }
}