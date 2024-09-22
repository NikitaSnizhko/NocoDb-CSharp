using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Annotations;

namespace NocoDb.Utils
{
    /// <summary>
    /// Url constants for interacting with records in NocoDb.
    /// </summary>
    public static class RecordUrlConstants
    {
        /// <summary>
        /// Used to get the URL template without base URL.
        /// </summary>
        /// <param name="tableId">Id of the table to interact.</param>
        /// <param name="recordId">Id of the certain record in the table.</param>
        /// <param name="fields">Table fields that have to listed in the response.</param>
        /// <returns>Url like /api/v2/tables/{tableId}/records/{recordId}</returns>
        public static string GetRecordUrl(
            [NotNull]string tableId, 
            [NotNull]string recordId, 
            List<string> fields = null)
        {
            if(string.IsNullOrEmpty(tableId)) throw new ArgumentNullException(nameof(tableId));
            if(string.IsNullOrEmpty(recordId)) throw new ArgumentNullException(nameof(recordId));
            var requestUrl = $"/api/v2/tables/{tableId}/records/{recordId}";
            if (fields == null || !fields.Any()) return requestUrl;
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["fields"] = string.Join(",", fields);
            return $"{requestUrl}?{query}";
        }

        /// <summary>
        /// Used to get the URL template without base URL.
        /// </summary>
        /// <param name="tableId">Id of the table to interact.</param>
        /// <returns>Url like /api/v2/tables/{tableId}/records</returns>
        public static string GetTemplateRecordsUrl(string tableId)
        {
            return $"/api/v2/tables/{tableId}/records";
        }

        /// <summary>
        /// Used to get the URL template for query-parametrized request without base URL.
        /// </summary>
        /// <param name="tableId">Id of the table to interact.</param>
        /// <param name="limit">OPTIONAL. Define how many records return from one request. Available values 1 - 1000</param>
        /// <param name="offset">OPTIONAL. Define how many records skip. Used for pagination.</param>
        /// <param name="fields">OPTIONAL. Define list of fields(columns) to return.</param>
        /// <param name="where">OPTIONAL. Filter the records on the server side. Use tuple("fieldName","value")</param>
        /// <returns>Url like /api/v2/tables/{tableId}/records?limit={value}&amp;offset={value}&amp;fields=value1,value2,...&amp;where=({fieldName},eq,{value})~and(...)</returns> 
        public static string GetAllRecordsUrl(string tableId, int limit = default, int offset = default,
            List<string> fields = null, List<(string, string)> where = null)
        {
            var requestUrl = GetTemplateRecordsUrl(tableId);
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (limit != default)
            {
                query["limit"] = limit.ToString();
            }

            if (offset != default)
            {
                query["offset"] = offset.ToString();
            }

            if (fields != null)
            {
                query["fields"] = string.Join(",", fields);
            }

            if (where != null)
            {
                query["where"] = CreateWhereParameter(where);
            }

            var queryString = query.ToString();
            return string.IsNullOrEmpty(queryString) ? requestUrl : $"{requestUrl}?{queryString}";


            string CreateWhereParameter(List<(string, string)> whereParam)
            {
                var whereConditions =
                    whereParam.Select(condition => $"({condition.Item1},eq,{condition.Item2})");
                return string.Join("~and", whereConditions);
            }
        }



        /// <summary>
        /// Used to get the URL template for count-request without base URL.
        /// </summary>
        /// <param name="tableId">Id of the table to interact.</param>
        /// <returns>Url like /api/v2/tables/{tableId}/records/count</returns>
        public static string GetTemplateCountRecordUrl(string tableId)
        {
            return $"/api/v2/tables/{tableId}/records/count";
        }
    }
}