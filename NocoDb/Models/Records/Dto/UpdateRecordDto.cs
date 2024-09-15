using System.Collections.Generic;

namespace NocoDb.Models.Records.Dto
{
    /// <summary>
    /// Use this class to pass query parameters to request to get records from the table.
    /// </summary>
    public class UpdateRecordDto
    {
        /// <summary>
        /// Pass field names that you want to get from the table. Only this fields will be returned.
        /// </summary>
        public List<string> Fields { get; set; }
        
        /// <summary>
        /// Add where conditions to filter records.
        /// Read more about where conditions in NocoDb documentation: https://data-apis-v2.nocodb.com/#tag/Table-Records/operation/db-data-table-row-list
        /// First string in tuple is the field(column) name, second is the value.
        /// </summary>
        public List<(string,string)> Where { get; set; }
        
        /// <summary>
        /// Pass the number of records you want to get in single request. Available values: 1-1000.
        /// </summary>
        public int Limit { get; set; }
        
        /// <summary>
        /// Use this parameter to get records from the certain position. Used for pagination.
        /// </summary>
        public int Offset { get; set; }
    }
}