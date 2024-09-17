using System;
using System.Threading.Tasks;
using NocoDb.Utils;
using Newtonsoft.Json;
using NocoDb.Models.Tables.Response;

namespace NocoDb.Services
{
    public partial class NocoClient 
    {
        /// <summary>
        /// List all tables in the database.
        /// Official API reference: <a href="https://meta-apis-v2.nocodb.com/#tag/DB-Table/operation/db-table-list">List Tables</a>
        /// </summary>
        /// <param name="baseId">Id of DB where search for tables.</param>
        /// <returns></returns>
        public async Task<OperationResult<GetAllTablesResponse>> GetAllTablesInBase(string baseId)
        {
            try
            {
                var url = TableUrlConstants.GetAllTablesUrl(baseId);
                //Query parameters are not included because they do not work in my tests in Insomnia.
                var response = await httpClient.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new OperationResult<GetAllTablesResponse>()
                    {
                        Success = false,
                        ErrorMessage = responseContent
                    };
                }

                var tables = JsonConvert.DeserializeObject<GetAllTablesResponse>(responseContent);
                return new OperationResult<GetAllTablesResponse>()
                {
                    Success = true,
                    Result = tables
                };

            }
            catch (Exception e)
            {
                return new OperationResult<GetAllTablesResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
    }
}