using Newtonsoft.Json;

namespace NocoDb.Models.Tables;

public class NormalColumnModel
{
    [JsonProperty("column_name")]
    public string ColumnName { get; set; }
    
    [JsonProperty("title", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Title { get; set; }
    
    [JsonProperty("ai", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsAutoIncremented { get; set; }
    
    [JsonProperty("altered", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Altered { get; set; }
    
    [JsonProperty("cdf", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public object ColumnDefaultValue { get; set; }
    
    [JsonProperty("ck", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Ck { get; set; }
    
    [JsonProperty("clen", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public object Clen { get; set; }
    
    [JsonProperty("ct", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ColumnType { get; set; }
    
    [JsonProperty("dt", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string DataType { get; set; }
    
    [JsonProperty("dtx", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string DataTypeExtra { get; set; }
    
    [JsonProperty("dtxp", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string DataTypeExtraPrecision { get; set; }
    
    [JsonProperty("dtxs", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string DataTypeExtraScale { get; set; }
    
    [JsonProperty("np", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int NumericPrecision { get; set; }
    
    [JsonProperty("nrqd", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Nrqd { get; set; }
    
    [JsonProperty("ns", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int NumericScale { get; set; }
    
    [JsonProperty("pk", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsPrimaryKey { get; set; }
    
    [JsonProperty("rqd", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsRequired { get; set; }
    
    [JsonProperty("uicn", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Uicn { get; set; }
    
    [JsonProperty("uidt", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string UiDataType { get; set; }
    
    [JsonProperty("uip", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Uip { get; set; }
    
    [JsonProperty("un", 
        NullValueHandling = NullValueHandling.Ignore, 
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsColumnUnique { get; set; }
}