using System;
using JetBrains.Annotations;

namespace NocoDb.Models.Tables.RequestParameters;

public class CreateColumnParameters(
    [NotNull]string columnName,
    ColumnDataType columnDataType)
{
    public string ColumnName { get; set; } = columnName ?? throw new ArgumentNullException(nameof(columnName));
    
    public string Title { get; set; }
    
    public bool IsAutoIncremented { get; set; }
    
    public int Altered { get; set; }
    
    public object ColumnDefaultValue { get; set; }
    
    public bool Ck { get; set; }
    
    public object Clen { get; set; }
    
    public string ColumnType { get; set; }
    
    public string DataType { get; set; }
    
    public string DataTypeExtra { get; set; }
    
    public string DataTypeExtraPrecision { get; set; }
    
    public string DataTypeExtraScale { get; set; }
    
    public int NumericPrecision { get; set; }
    
    public bool Nrqd { get; set; }
    
    public int NumericScale { get; set; }
    
    public bool IsPrimaryKey { get; set; }
    
    public bool IsRequired { get; set; }
    
    public string Uicn { get; set; }
    
    public ColumnDataType UiDataType { get; set; } = columnDataType;
    
    public string Uip { get; set; }
    
    public bool IsColumnUnique { get; set; }
    
    public NormalColumnModel ToNormalColumnModel()
    {
        return new NormalColumnModel()
        {
            ColumnName = ColumnName,
            Title = Title,
            IsAutoIncremented = IsAutoIncremented,
            Altered = Altered,
            ColumnDefaultValue = ColumnDefaultValue,
            Ck = Ck,
            Clen = Clen,
            ColumnType = ColumnType,
            DataType = DataType,
            DataTypeExtra = DataTypeExtra,
            DataTypeExtraPrecision = DataTypeExtraPrecision,
            DataTypeExtraScale = DataTypeExtraScale,
            NumericPrecision = NumericPrecision,
            Nrqd = Nrqd,
            NumericScale = NumericScale,
            IsPrimaryKey = IsPrimaryKey,
            IsRequired = IsRequired,
            Uicn = Uicn,
            UiDataType = ColumnDataTypeHelper.GetColumnDataTypeString(UiDataType),
            Uip = Uip,
            IsColumnUnique = IsColumnUnique
        };
    }
}

