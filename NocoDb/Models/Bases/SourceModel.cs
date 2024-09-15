using System;
using Newtonsoft.Json;

namespace NocoDb.Models.Bases
{
    public class SourceModel
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("config")]
        public object Config { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inflection_column")]
        public string InflectionColumn { get; set; }

        [JsonProperty("inflection_table")]
        public string InflectionTable { get; set; }

        [JsonProperty("is_meta")]
        public bool IsMeta { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("base_id")]
        public string BaseId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}