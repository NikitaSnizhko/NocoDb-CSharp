using System.Collections.Generic;

namespace NocoDb.Models.Records.Request;

public class CreateRecordsRequest<T>
{
    public List<T> Records { get; set; }
}