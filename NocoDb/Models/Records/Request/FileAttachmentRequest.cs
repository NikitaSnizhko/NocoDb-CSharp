using System;
using JetBrains.Annotations;

namespace NocoDb.Models.Records.Request;

public class FileAttachmentRequest([NotNull]string fileName, [NotNull]byte[] content)
{
    public string FileName { get; set; } = string.IsNullOrEmpty(fileName) 
            ? throw new ArgumentNullException(nameof(fileName)) 
            : fileName;
    public byte[] Content { get; set; } = content ?? throw new ArgumentNullException(nameof(content));
}