using System.Dynamic;
using Newtonsoft.Json;

namespace NocoDb.Models.Records.Response;

public class GetRecordResponse
{
    [JsonExtensionData]
    public ExpandoObject Fields { get; set; }
}