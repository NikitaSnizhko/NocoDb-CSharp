using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NocoDb.Models.Tables.RequestParameters;

/// <summary>
/// Parameters object to create a table.
/// </summary>
/// <param name="dataBaseId">Id of db where to create table.</param>
/// <param name="tableName">Name of the table</param>
/// <param name="createDefaultIdColumn">Determine whether to create default Id column or not.
/// If false: it is mandatory to configure and pass the ID-column instance to the ColumnsData manually.</param>
public class CreateTableParameters(
    [NotNull]string dataBaseId,
    [NotNull]string tableName,
    bool createDefaultIdColumn = true)
{
    public string TableName { get; set; } = tableName ?? throw new ArgumentNullException(nameof(tableName));
    
    public string DadaBaseId { get; set; } = dataBaseId ?? throw new ArgumentNullException(nameof(dataBaseId));
    
    public List<CreateColumnParameters> ColumnsData { get; set; }
    
    public string TableTitle { get; set; }
    
    public bool CreateDefaultIdColumn { get; set; } = createDefaultIdColumn;
}