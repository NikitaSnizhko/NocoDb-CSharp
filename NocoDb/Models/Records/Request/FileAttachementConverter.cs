using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NocoDb.Utils;

namespace NocoDb.Models.Records.Request;

public class FileAttachmentConverter(HttpClient httpClient) : JsonConverter<List<FileAttachmentRequest>>
{
    public override void WriteJson(JsonWriter writer, List<FileAttachmentRequest> value, JsonSerializer serializer)
    {
        var attachmentRequests = value.Select(file => (file.FileName, file.Content)).ToList();
        
        var fileUploadResponse = UploadFilesAsync(attachmentRequests).GetAwaiter().GetResult();
        writer.WriteRawValue(fileUploadResponse);
    }

    public override List<FileAttachmentRequest> ReadJson(JsonReader reader, Type objectType, List<FileAttachmentRequest> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    private async Task<string> UploadFilesAsync(List<(string fileName, byte[] fileContent)> files)
    {
        return await FileOperations.UploadFiles(files, httpClient);
    }
}