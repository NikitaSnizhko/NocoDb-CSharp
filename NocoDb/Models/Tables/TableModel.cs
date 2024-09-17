using System;
using Newtonsoft.Json;

namespace NocoDb.Models.Tables;

public class TableModel
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("source_id")]
    public string SourceId { get; set; }

    [JsonProperty("base_id")]
    public string BaseId { get; set; }

    [JsonProperty("table_name")]
    public string TableName { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("meta")]
    public object Meta { get; set; }

    [JsonProperty("schema")]
    public object Schema { get; set; }

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("mm")]
    public bool Mm { get; set; }

    [JsonProperty("tags")]
    public object Tags { get; set; }

    [JsonProperty("pinned")]
    public object Pinned { get; set; }

    [JsonProperty("deleted")]
    public object Deleted { get; set; }

    [JsonProperty("order")]
    public string Order { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("description")]
    public object Description { get; set; }
}