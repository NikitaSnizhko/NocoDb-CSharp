using System.Collections.Generic;
using Newtonsoft.Json;

namespace NocoDb.Models.Tables.Response;

public class GetAllTablesResponse
{
    [JsonProperty("list")]
    public List<TableModel> Tables { get; set; }
}