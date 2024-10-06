using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NocoDb.Models.Records.RequestParameters;

public class GetRecordParameters([NotNull]string tableId,[NotNull] string recordId)
{
    public string TableId { get; set; } = tableId ?? throw new ArgumentNullException(nameof(tableId));
    
    public string RecordId { get; set; } = recordId ?? throw new ArgumentNullException(nameof(recordId));
    
    public List<string> Fields { get; set; }
}