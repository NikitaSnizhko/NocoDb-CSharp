using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace NocoDb.Models.Tables.RequestParameters;

public class UpdateTableParameters([NotNull]string tableId)
{
    public string TableId { get; set; } = tableId ?? throw new ArgumentNullException(nameof(tableId));
    
    public string TableName { get; set; }
    
    public string Title { get; set; }
    
    public string BaseId { get; set; }
    
    public object Meta { get; set; }
}