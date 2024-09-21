using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NocoDb.Utils;
using Newtonsoft.Json;
using NocoDb.Extensions;
using NocoDb.Models.Tables;
using NocoDb.Models.Tables.Request;
using NocoDb.Models.Tables.RequestParameters;
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
                        ErrorMessage = $"Error getting tables. Status code: {response.StatusCode}"
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
        
        
        /// <summary>
        /// Create a new table in the database.
        /// Official API reference: <a href="https://meta-apis-v2.nocodb.com/#tag/DB-Table/operation/db-table-create">Create Table</a>
        /// </summary>
        /// <param name="tableParameters">Parameters for table creation.</param>
        /// <returns></returns>
        public async Task<OperationResult<CreateTableResponse>> CreateTable(CreateTableParameters tableParameters)
        {
            try
            {
                var createTableRequest = new CreateTableRequest(tableParameters.CreateDefaultIdColumn)
                {
                    TableName = tableParameters.TableName,
                    TableTitle = tableParameters.TableTitle
                };
                // Add columns to the request like this because, in the constructor of CreateTableRequest, the default ID column is already added.
                if(tableParameters.ColumnsData != null && tableParameters.ColumnsData.Any())
                    createTableRequest.Columns
                        .AddRange(tableParameters.ColumnsData
                            .Select(x => x.ToNormalColumnModel()));
                
                var createTableRequestJson = JsonConvert.SerializeObject(createTableRequest);
                var httpContent = new StringContent(createTableRequestJson, System.Text.Encoding.UTF8, MediaTypes.ApplicationJson);
                var url = TableUrlConstants.CreateTableUrl(tableParameters.DadaBaseId);
                var createTableResponse = await httpClient.PostAsync(url, httpContent);
                
                if (!createTableResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<CreateTableResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Error creating table. Status code: {createTableResponse.StatusCode}"
                    };
                }

                var tableResponseString = await createTableResponse.Content.ReadAsStringAsync();
                var tableObject = JsonConvert.DeserializeObject<CreateTableResponse>(tableResponseString);
                return new OperationResult<CreateTableResponse>()
                {
                    Success = true,
                    Result = tableObject
                };

            }
            catch (Exception e)
            {
                return new OperationResult<CreateTableResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
        
        
        /// <summary>
        /// Get a table by its ID.
        /// Official API reference: <a href="https://meta-apis-v2.nocodb.com/#tag/DB-Table/operation/db-table-read">Get Table</a>
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetTableResponse>> GetTable([NotNull]string tableId)
        {
            try
            {
                var url = TableUrlConstants.GetTableUrl(tableId);
                var response = await httpClient.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new OperationResult<GetTableResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Error getting table. Status code: {response.StatusCode}"
                    };
                }

                var table = JsonConvert.DeserializeObject<GetTableResponse>(responseContent);
                return new OperationResult<GetTableResponse>()
                {
                    Success = true,
                    Result = table
                };

            }
            catch (Exception e)
            {
                return new OperationResult<GetTableResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
        
        
        /// <summary>
        /// Update a table.
        /// Official API reference: <a href="https://meta-apis-v2.nocodb.com/#tag/DB-Table/operation/db-table-update">Update Table</a>
        /// </summary>
        /// <param name="updateTableParameters"></param>
        /// <returns>True if the table was updated successfully, otherwise false.</returns>
        public async Task<OperationResult<bool>> UpdateTable([NotNull]UpdateTableParameters updateTableParameters)
        {
            try
            {
                var updateTableRequest = new UpdateTableRequest()
                {
                    TableName = updateTableParameters.TableName,
                    Title = updateTableParameters.Title,
                    BaseId = updateTableParameters.BaseId,
                    Meta = updateTableParameters.Meta
                };
                var updateTableRequestJson = JsonConvert.SerializeObject(updateTableRequest);
                var httpContent = new StringContent(updateTableRequestJson, System.Text.Encoding.UTF8, MediaTypes.ApplicationJson);
                var url = TableUrlConstants.UpdateTableUrl(updateTableParameters.TableId);
                var updateTableResponse = await httpClient.PatchAsync(url, httpContent);
                
                if (!updateTableResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<bool>()
                    {
                        Success = false,
                        ErrorMessage = $"Error updating table. Status code: {updateTableResponse.StatusCode}"
                    };
                }

                return new OperationResult<bool>()
                {
                    Success = true,
                    Result = true
                };

            }
            catch (Exception e)
            {
                return new OperationResult<bool>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }

        
        /// <summary>
        /// Delete a table.
        /// Official API reference: <a href="https://meta-apis-v2.nocodb.com/#tag/DB-Table/operation/db-table-delete">Delete Table</a>
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns>True if the table was deleted successfully, otherwise false.</returns>
        public async Task<OperationResult<bool>> DeleteTable([NotNull] string tableId)
        {
            try
            {
                var url = TableUrlConstants.DeleteTableUrl(tableId);
                var response = await httpClient.DeleteAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new OperationResult<bool>()
                    {
                        Success = false,
                        ErrorMessage = $"Error deleting table. Status code: {response.StatusCode}"
                    };
                }

                return new OperationResult<bool>()
                {
                    Success = true,
                    Result = true
                };

            }
            catch (Exception e)
            {
                return new OperationResult<bool>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
    }
}