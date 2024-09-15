using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NocoDb.Models.Bases
{
    public class BaseModel
    {
        [JsonProperty("sources")]
        public List<SourceModel> Sources { get; set; }
        
        [JsonProperty("color")]
        public string Color { get; set; }
        
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("is_meta")]
        public bool IsMeta { get; set; }
        
        [JsonProperty("meta")]
        public Dictionary<string, object> Meta { get; set; }
        
        [JsonProperty("order")]
        public int Order { get; set; }
        
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}