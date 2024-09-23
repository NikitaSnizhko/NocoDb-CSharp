using Newtonsoft.Json;

namespace NocoDb.Models.Records;

public class Attachment
{
    [JsonProperty("path")]
    public string Path { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("mimetype")]
    public string Mimetype { get; set; }
    
    [JsonProperty("size")]
    public int Size { get; set; }
    
    /*[JsonProperty("icon")]
    public string Icon { get; set; }*/
    
    [JsonProperty("signedPath")]
    public string SignedPath { get; set; }
}