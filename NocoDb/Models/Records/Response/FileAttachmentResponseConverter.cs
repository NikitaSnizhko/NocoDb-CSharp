using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NocoDb.Utils;

namespace NocoDb.Models.Records.Response;

/// <summary>
/// Custom JsonConverter to catch the file attachment and download the file content.
/// </summary>
/// <param name="client"></param>
public class FileAttachmentResponseConverter(HttpClient client) : JsonConverter<List<FileAttachmentResponse>>
{
    public override List<FileAttachmentResponse> ReadJson(JsonReader reader, Type objectType, List<FileAttachmentResponse> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var jsonArray = JArray.Load(reader);
        var fileAttachmentResponses = new List<FileAttachmentResponse>();

        foreach (var item in jsonArray)
        {
            var fileAttachmentResponse = item.ToObject<FileAttachmentResponse>();

            // Download the file content
            var urls = new List<(string,string)> { (fileAttachmentResponse.Title, fileAttachmentResponse.SignedPath) };
            var response = FileOperations.DownloadFiles(urls, client).GetAwaiter().GetResult();
            fileAttachmentResponse.File = response.FirstOrDefault();

            fileAttachmentResponses.Add(fileAttachmentResponse);
        }

        return fileAttachmentResponses;
    }

    public override void WriteJson(JsonWriter writer, List<FileAttachmentResponse> value, JsonSerializer serializer)
    {
        throw new NotImplementedException("Writing JSON is not implemented.");
    }
}