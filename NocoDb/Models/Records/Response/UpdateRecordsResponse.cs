using System.Collections.Generic;

namespace NocoDb.Models.Records.Response;

public class UpdateRecordsResponse
{
    public List<object> Records { get; set; } = [];
}