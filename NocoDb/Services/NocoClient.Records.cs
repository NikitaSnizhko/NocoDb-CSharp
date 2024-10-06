using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NocoDb.Extensions;
using NocoDb.Models.Records.Request;
using NocoDb.Models.Records.RequestParameters;
using NocoDb.Models.Records.Response;
using NocoDb.Utils;

namespace NocoDb.Services;

public partial class NocoClient
{
    /// <summary>
    /// Get a record as a json string.
    /// Official API reference: <a href="https://data-apis-v2.nocodb.com/#tag/Table-Records/operation/db-data-table-row-read">Read record.</a>
    /// </summary>
    /// <param name="getRecordParams">Parameters to get the record.</param>
    /// <returns>String json object.</returns>
    public async Task<OperationResult<string>> GetRecordAsString([NotNull]GetRecordParameters getRecordParams)
    {
        try
        {
            var getRecordQueryString = RecordUrlConstants.GetRecordUrl(
                getRecordParams.TableId,
                getRecordParams.RecordId,
                getRecordParams.Fields);
            
            var recordResponse = await httpClient.GetAsync(getRecordQueryString);
            
            if (!recordResponse.IsSuccessStatusCode)
            {
                return new OperationResult<string>()
                {
                    Success = false,
                    ErrorMessage = $"Error getting record. Error StatusCode: {recordResponse.StatusCode}"
                };
            }
            var recordResponseString = await recordResponse.Content.ReadAsStringAsync();
            return new OperationResult<string>()
            {
                Success = true,
                Result = recordResponseString
            };
        }
        catch (Exception ex)
        {
            return new OperationResult<string>()
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }
    
    /// <summary>
    /// Get a record as a custom type.
    /// Official API reference: <a href="https://data-apis-v2.nocodb.com/#tag/Table-Records/operation/db-data-table-row-read">Read record.</a>
    /// </summary>
    /// <param name="getRecordParams">Parameters to get a record.</param>
    /// <typeparam name="T">Type to automatically map the response.</typeparam>
    /// <returns>Strongly typed response instance.</returns>
    public async Task<OperationResult<T>> GetRecordAsType<T>([NotNull]GetRecordParameters getRecordParams)
    {
        try
        {
            var getRecordQueryString = RecordUrlConstants.GetRecordUrl(
                getRecordParams.TableId,
                getRecordParams.RecordId,
                getRecordParams.Fields);
            
            var recordResponse = await httpClient.GetAsync(getRecordQueryString);
            
            if (!recordResponse.IsSuccessStatusCode)
            {
                return new OperationResult<T>()
                {
                    Success = false,
                    ErrorMessage = $"Error getting record. Error StatusCode: {recordResponse.StatusCode}"
                };
            }
            var recordResponseString = await recordResponse.Content.ReadAsStringAsync();
            
            //This converter allows to download file attachments if any in the response.
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new FileAttachmentResponseConverter(httpClient));
            
            var recordResponseObject = JsonConvert.DeserializeObject<T>(recordResponseString, settings);
            return new OperationResult<T>()
            {
                Success = true,
                Result = recordResponseObject
            };
        }
        catch (Exception ex)
        {
            return new OperationResult<T>()
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }
    
    /// <summary>
    /// Create records in a table.
    /// Official API reference: <a href="https://data-apis-v2.nocodb.com/#tag/Table-Records/operation/db-data-table-row-create">Create records.</a>
    /// </summary>
    /// <param name="createRecordsParameters">Parameters to create a records.</param>
    /// <typeparam name="T">Type to automatically map the request.</typeparam>
    /// <returns>Return the string object which contains the created records Ids(or other primary key field).</returns>
    public async Task<OperationResult<CreateRecordsResponse>> CreateRecords<T>(
        [NotNull]CreateRecordsParameters<T> createRecordsParameters)
    {
        try
        {
            if(createRecordsParameters.Records == null || createRecordsParameters.Records.Count == 0)
            {
                return new OperationResult<CreateRecordsResponse>()
                {
                    Success = false,
                    ErrorMessage = "No records to create."
                };
            }
            // Add custom converters to flexibly parse FileAttachments if any in the request were passed.
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new FileAttachmentConverter(httpClient));
            
            var createRecordRequestJson = JsonConvert.SerializeObject(createRecordsParameters.Records, settings);
            var createRecordContent = new StringContent(createRecordRequestJson, System.Text.Encoding.UTF8, MediaTypes.ApplicationJson);
            var createRecordUrl = RecordUrlConstants.CreateRecordUrl(createRecordsParameters.TableId);
            
            var createRecordResponse = await httpClient.PostAsync(createRecordUrl, createRecordContent);
            
            if (!createRecordResponse.IsSuccessStatusCode)
            {
                return new OperationResult<CreateRecordsResponse>()
                {
                    Success = false,
                    ErrorMessage = $"Error creating records. Error StatusCode: {createRecordResponse.StatusCode}"
                };
            }
            var createRecordResponseString = await createRecordResponse.Content.ReadAsStringAsync();
            var createRecordResponseObject = JsonConvert.DeserializeObject<List<object>>(createRecordResponseString);
            var createRecordResponseInstance = new CreateRecordsResponse()
            {
                Records = createRecordResponseObject
            };
            return new OperationResult<CreateRecordsResponse>()
            {
                Success = true,
                Result = createRecordResponseInstance
            };
        }
        catch (Exception ex)
        {
            return new OperationResult<CreateRecordsResponse>()
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }

    
    /// <summary>
    /// Update records in a table.
    /// </summary>
    /// <param name="updateRecordsParameters">Parameters to update a records.</param>
    /// <typeparam name="T">Type to automatically map the request.</typeparam>
    /// <returns>Return the string object which contains the updated records Ids(or other primary key field).</returns>
    public async Task<OperationResult<UpdateRecordsResponse>> UpdateRecords<T>(
        [NotNull] UpdateRecordsParameters<T> updateRecordsParameters)
    {
        try
        {
            if(updateRecordsParameters.Records == null || updateRecordsParameters.Records.Count == 0)
            {
                return new OperationResult<UpdateRecordsResponse>()
                {
                    Success = false,
                    ErrorMessage = "No records to update."
                };
            }
            // Add custom converters to flexibly parse FileAttachments if any in the request were passed.
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new FileAttachmentConverter(httpClient));
            
            var updateRecordRequestJson = JsonConvert.SerializeObject(updateRecordsParameters.Records, settings);
            var updateRecordContent = new StringContent(updateRecordRequestJson, System.Text.Encoding.UTF8, MediaTypes.ApplicationJson);
            var updateRecordUrl = RecordUrlConstants.UpdateRecordsUrl(updateRecordsParameters.TableId);
            
            var updateRecordResponse = await httpClient.PatchAsync(updateRecordUrl, updateRecordContent);
            
            if (!updateRecordResponse.IsSuccessStatusCode)
            {
                return new OperationResult<UpdateRecordsResponse>()
                {
                    Success = false,
                    ErrorMessage = $"Error updating records. Error StatusCode: {updateRecordResponse.StatusCode}"
                };
            }
            var updateRecordResponseString = await updateRecordResponse.Content.ReadAsStringAsync();
            var updateRecordResponseObject = JsonConvert.DeserializeObject<List<object>>(updateRecordResponseString);
            var updateRecordResponseInstance = new UpdateRecordsResponse()
            {
                Records = updateRecordResponseObject
            };
            return new OperationResult<UpdateRecordsResponse>()
            {
                Success = true,
                Result = updateRecordResponseInstance
            };
        }
        catch (Exception ex)
        {
            return new OperationResult<UpdateRecordsResponse>()
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }
    
    
    /// <summary>
    /// Delete records in a table.
    /// </summary>
    /// <param name="deleteRecordsParameters">Parameters to delete a records.</param>
    /// <typeparam name="T">Type to automatically map the request.</typeparam>
    /// <returns>Return the string object which contains the deleted records Ids(or other primary key field).</returns>
    public async Task<OperationResult<DeleteRecordsResponse>> DeleteRecords<T>(
        [NotNull] DeleteRecordsParameters<T> deleteRecordsParameters)
    {
        try
        {
            if(deleteRecordsParameters.Records == null || deleteRecordsParameters.Records.Count == 0)
            {
                return new OperationResult<DeleteRecordsResponse>()
                {
                    Success = false,
                    ErrorMessage = "No records to delete."
                };
            }
            
            var deleteRecordRequestJson = JsonConvert.SerializeObject(deleteRecordsParameters.Records);
            var deleteRecordContent = new StringContent(deleteRecordRequestJson, System.Text.Encoding.UTF8, MediaTypes.ApplicationJson);
            var deleteRecordUrl = RecordUrlConstants.DeleteRecordsUrl(deleteRecordsParameters.TableId);
            
            var deleteRecordResponse = await httpClient.DeleteAsync(deleteRecordUrl, deleteRecordContent);
            
            if (!deleteRecordResponse.IsSuccessStatusCode)
            {
                return new OperationResult<DeleteRecordsResponse>()
                {
                    Success = false,
                    ErrorMessage = $"Error deleting records. Error StatusCode: {deleteRecordResponse.StatusCode}"
                };
            }
            var deleteRecordResponseString = await deleteRecordResponse.Content.ReadAsStringAsync();
            var deleteRecordResponseObject = JsonConvert.DeserializeObject<List<object>>(deleteRecordResponseString);
            var deleteRecordResponseInstance = new DeleteRecordsResponse()
            {
                Records = deleteRecordResponseObject
            };
            return new OperationResult<DeleteRecordsResponse>()
            {
                Success = true,
                Result = deleteRecordResponseInstance
            };
        }
        catch (Exception ex)
        {
            return new OperationResult<DeleteRecordsResponse>()
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }
}