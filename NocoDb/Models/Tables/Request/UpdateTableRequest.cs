using Newtonsoft.Json;

namespace NocoDb.Models.Tables.Request;

public class UpdateTableRequest
{
    [JsonProperty("table_name", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TableName { get; set; }
    
    [JsonProperty("title", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Title { get; set; }
    
    [JsonProperty("base_id", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string BaseId { get; set; }
    
    [JsonProperty("meta", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public object Meta { get; set; }
}