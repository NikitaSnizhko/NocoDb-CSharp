using Newtonsoft.Json;

namespace NocoDb.Models.Records.Response;

public class FileAttachmentResponse
{
    [JsonProperty("path")]
    public string Path { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("mimetype")]
    public string Mimetype { get; set; }
    
    [JsonProperty("size")]
    public int Size { get; set; }
    
    [JsonProperty("signedPath")]
    public string SignedPath { get; set; }
    
    
    /// <summary>
    /// This property is not part of the JSON response. It is used to store the file content after downloading it.
    /// It is used by the custom JsonConverter <see cref="FileAttachmentResponseConverter"/>.
    /// </summary>
    public (string fileName, byte[] fileContent) File { get; set; }
}