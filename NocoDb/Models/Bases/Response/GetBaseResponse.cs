using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NocoDb.Models.Bases.Response;

public class GetBaseResponse
{
    [JsonProperty("is_meta")] 
    public bool IsMeta { get; set; }

    [JsonProperty("id")] 
    public string Id { get; set; }

    [JsonProperty("title")] 
    public string Title { get; set; }

    [JsonProperty("prefix")] 
    public string Prefix { get; set; }

    [JsonProperty("status")] 
    public string Status { get; set; }

    [JsonProperty("description")] 
    public string Description { get; set; }

    [JsonProperty("meta")] 
    public string Meta { get; set; }

    [JsonProperty("color")] 
    public string Color { get; set; }

    [JsonProperty("uuid")] 
    public string Uuid { get; set; }

    [JsonProperty("password")] 
    public string Password { get; set; }

    [JsonProperty("roles")] 
    public string Roles { get; set; }

    [JsonProperty("deleted")] 
    public bool Deleted { get; set; }

    [JsonProperty("order")] 
    public int Order { get; set; }

    [JsonProperty("created_at")] 
    public string CreatedAt { get; set; }

    [JsonProperty("updated_at")] 
    public string UpdatedAt { get; set; }
    
    [JsonProperty("sources")]
    public List<SourceModel> Sources { get; set; }
    }