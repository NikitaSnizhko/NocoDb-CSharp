using System;

namespace NocoDb.Models.Tables;

public enum ColumnDataType
{
    Attachment,
    AutoNumber,
    Barcode,
    Button,
    Checkbox,
    Collaborator,
    Count,
    CreatedTime,
    Currency,
    Date,
    DateTime,
    Decimal,
    Duration,
    Email,
    Formula,
    ForeignKey,
    GeoData,
    Geometry,
    ID,
    JSON,
    LastModifiedTime,
    LongText,
    LinkToAnotherRecord,
    Lookup,
    MultiSelect,
    Number,
    Percent,
    PhoneNumber,
    Rating,
    Rollup,
    SingleLineText,
    SingleSelect,
    SpecificDBType,
    Time,
    URL,
    Year,
    QrCode,
    Links,
    User,
    //CreatedBy,//This option throws an error so for now it is skipped.
    LastModifiedBy
}

public class ColumnDataTypeHelper()
{
    public static string GetColumnDataTypeString(ColumnDataType columnDataType)
    {
        return columnDataType switch
        {
            ColumnDataType.Attachment => "Attachment",
            ColumnDataType.AutoNumber => "AutoNumber",
            ColumnDataType.Barcode => "Barcode",
            ColumnDataType.Button => "Button",
            ColumnDataType.Checkbox => "Checkbox",
            ColumnDataType.Collaborator => "Collaborator",
            ColumnDataType.Count => "Count",
            ColumnDataType.CreatedTime => "CreatedTime",
            ColumnDataType.Currency => "Currency",
            ColumnDataType.Date => "Date",
            ColumnDataType.DateTime => "DateTime",
            ColumnDataType.Decimal => "Decimal",
            ColumnDataType.Duration => "Duration",
            ColumnDataType.Email => "Email",
            ColumnDataType.Formula => "Formula",
            ColumnDataType.ForeignKey => "ForeignKey",
            ColumnDataType.GeoData => "GeoData",
            ColumnDataType.Geometry => "Geometry",
            ColumnDataType.ID => "ID",
            ColumnDataType.JSON => "JSON",
            ColumnDataType.LastModifiedTime => "LastModifiedTime",
            ColumnDataType.LongText => "LongText",
            ColumnDataType.LinkToAnotherRecord => "LinkToAnotherRecord",
            ColumnDataType.Lookup => "Lookup",
            ColumnDataType.MultiSelect => "MultiSelect",
            ColumnDataType.Number => "Number",
            ColumnDataType.Percent => "Percent",
            ColumnDataType.PhoneNumber => "PhoneNumber",
            ColumnDataType.Rating => "Rating",
            ColumnDataType.Rollup => "Rollup",
            ColumnDataType.SingleLineText => "SingleLineText",
            ColumnDataType.SingleSelect => "SingleSelect",
            ColumnDataType.SpecificDBType => "SpecificDBType",
            ColumnDataType.Time => "Time",
            ColumnDataType.URL => "URL",
            ColumnDataType.Year => "Year",
            ColumnDataType.QrCode => "QrCode",
            ColumnDataType.Links => "Links",
            ColumnDataType.User => "User",
            //ColumnDataType.CreatedBy => "CreatedBy",
            ColumnDataType.LastModifiedBy => "LastModifiedBy",
            _ => throw new ArgumentOutOfRangeException(nameof(columnDataType), columnDataType, null)
        };
    }
}
    
            