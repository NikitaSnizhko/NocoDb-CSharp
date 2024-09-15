using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace NocoDb.Models.Bases.Dto;

public class CreateBaseDto
{
    public CreateBaseDto(
        [NotNull] string title)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title)); 
    }
        
    public string Color { get; set; }
        
    public string Description { get; set; }
        
    public int Order { get; set; }
        
    public string Status { get; set; }
        
    [NotNull]
    public string Title { get; set; }
}