using Newtonsoft.Json;

namespace NocoDb.Models.Bases.Request;

public class UpdateBaseRequest
{
    [JsonProperty(
        "title", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Title { get; set; }
        
    [JsonProperty(
        "color",
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Color { get; set; }
        
    [JsonProperty(
        "order", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Order { get; set; }
        
    [JsonProperty(
        "status", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Status { get; set; }
        
    [JsonProperty(
        "meta", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public object Meta { get; set; }
}