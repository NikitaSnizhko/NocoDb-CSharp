using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
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
    /// <param name="getRecordParams">Parameters to get the record.</param>
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
            var recordResponseObject = JsonConvert.DeserializeObject<T>(recordResponseString);
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
            /*var createRecordRequest = new CreateRecordsRequest<T>()
            {
                Records = createRecordsParameters.Records 
            };*/
            var createRecordRequestJson = JsonConvert.SerializeObject(createRecordsParameters.Records);
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
}