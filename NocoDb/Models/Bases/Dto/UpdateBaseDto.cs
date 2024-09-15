using System;
using JetBrains.Annotations;

namespace NocoDb.Models.Bases.Dto;

public class UpdateBaseDto
{
    public UpdateBaseDto(
        [NotNull] string databaseId)
    {
        Id = databaseId ?? throw new ArgumentNullException(nameof(databaseId)); 
    }
    public string Id { get; set; }
    
    public string Title { get; set; }
        
    public string Color { get; set; }
        
    public int Order { get; set; }
        
    public string Status { get; set; }
    
    public object Meta { get; set; }
}