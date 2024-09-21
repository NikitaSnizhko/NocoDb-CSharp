using Newtonsoft.Json;

namespace NocoDb.Models.Tables.Request;

public class DuplicateTableRequest
{
    [JsonProperty("excludeData")]
    public bool ExcludeData { get; set; }
    
    [JsonProperty("excludeViews")]
    public bool ExcludeViews { get; set; }
}