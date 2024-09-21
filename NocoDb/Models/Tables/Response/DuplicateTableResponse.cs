using Newtonsoft.Json;

namespace NocoDb.Models.Tables.Response;

public class DuplicateTableResponse
{
    [JsonProperty("id")]
    public string Id { get; set; }
}