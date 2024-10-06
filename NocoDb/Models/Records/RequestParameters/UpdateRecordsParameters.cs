using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NocoDb.Models.Records.RequestParameters;

public class UpdateRecordsParameters<T>([NotNull]string tableId)
{
    public string TableId { get; set; } = tableId ?? throw new ArgumentNullException(nameof(tableId)); 
    
    public List<T> Records { get; set; }
}