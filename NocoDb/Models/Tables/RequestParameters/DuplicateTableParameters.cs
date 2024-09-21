using System;
using JetBrains.Annotations;

namespace NocoDb.Models.Tables.RequestParameters;

public class DuplicateTableParameters(
    [NotNull]string baseId, 
    [NotNull]string tableId)
{
    public string BaseId { get; set; } = baseId ?? throw new ArgumentNullException(nameof(baseId));
    
    public string TableId { get; set; } = tableId ?? throw new ArgumentNullException(nameof(tableId));
    
    public bool ExcludeData { get; set; }
    
    public bool ExcludeViews { get; set; }
}