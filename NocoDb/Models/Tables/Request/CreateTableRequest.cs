using System.Collections.Generic;
using Newtonsoft.Json;

namespace NocoDb.Models.Tables.Request;

public class CreateTableRequest
{
    public CreateTableRequest(bool createDefaultIdColumn = true)
    {
        Columns = [];
        if (!createDefaultIdColumn) return;
        //Execute the method to create the default id column. Without this column, recently created table, will not work properly.
        //Safe way to add the id column automatically when the instance of the class is created.
        var idColumn = CreateDefaultIdColumn();
        Columns.Add(idColumn);
    }
    [JsonProperty("columns")]
    public List<NormalColumnModel> Columns { get; set; }
    
    [JsonProperty("table_name")]
    public string TableName { get; set; }
    
    [JsonProperty("title", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string TableTitle { get; set; }
    
    private static NormalColumnModel CreateDefaultIdColumn()
    {
        return new NormalColumnModel()
        {
            IsAutoIncremented = true,
            Altered = 1,
            ColumnDefaultValue = null,
            Ck = false,
            Clen = null,
            ColumnName = "id",
            ColumnType = "int(11)",
            DataType = "int",
            DataTypeExtra = "integer",
            DataTypeExtraPrecision = "11",
            DataTypeExtraScale = string.Empty,
            NumericPrecision = 11,
            Nrqd = false,
            NumericScale = 0,
            IsPrimaryKey = true,
            IsRequired = true,
            Title = "Id",
            Uicn = string.Empty,
            UiDataType = ColumnDataTypeHelper.GetColumnDataTypeString(ColumnDataType.ID),
            Uip = string.Empty,
            IsColumnUnique = true
        };
    }
}