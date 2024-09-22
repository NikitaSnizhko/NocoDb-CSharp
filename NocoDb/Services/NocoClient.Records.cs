using System;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NocoDb.Models.Records.RequestParameters;
using NocoDb.Models.Records.Response;
using NocoDb.Utils;

namespace NocoDb.Services;

public partial class NocoClient
{
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
    
    public async Task<OperationResult<T>> GetRecordTyped<T>([NotNull]GetRecordParameters getRecordParams)
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
}