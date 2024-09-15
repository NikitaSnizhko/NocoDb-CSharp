using Newtonsoft.Json;

namespace NocoDb.Models.Bases.Response;

public class ListBasesResponse
{
    [JsonProperty("list")]
    public BaseModel[] List { get; set; }
    
    [JsonProperty("pageInfo")]
    public PageInfo PageInfo { get; set; }
}