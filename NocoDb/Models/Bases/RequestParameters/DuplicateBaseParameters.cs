using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace NocoDb.Models.Bases.RequestParameters;

public class DuplicateBaseParameters(
    [NotNull]string baseId,
    bool excludeData = false,
    bool excludeViews = false,
    bool excludeHooks = false)
{
    public string BaseId { get; set; } = baseId ?? throw new ArgumentNullException(nameof(baseId));
    
    public bool ExcludeData { get; set; } = excludeData;
    
    public bool ExcludeViews { get; set; } = excludeViews;
    
    public bool ExcludeHooks { get; set; } = excludeHooks;
}