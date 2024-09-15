using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NocoDb.Utils;
using System.Text.Json;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NocoDb.Models.Bases.Response;
using NocoDb.Models.GeneralNocoUtils;
using NocoDb.Models.GeneralNocoUtils.Dto;
using NocoDb.Models.GeneralNocoUtils.Response;
using NocoDb.Models.GeneralNocoUtils.Request;
using NocoDb.Models.Records.Dto;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace NocoDb.Services
{
    public partial class NocoClient
    {
        /// <summary>
        /// Test if the database connection is available.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Utils/operation/utils-test-connection
        /// </summary>
        /// <param name="testDbConnectionDto"></param>
        /// <returns></returns>
        public async Task<OperationResult<TestDbConnectionResponse>> TestDbConnection(TestDbConnectionDto testDbConnectionDto)
        {
            try
            {
                var testDbConnectionRequest = new TestDbConnectionRequest()
                {
                    Client = DbTypeHelper.GetDbTypeString(testDbConnectionDto.Client),
                    Connection = new ConnectionData()
                    {
                        Host = testDbConnectionDto.Host,
                        Port = testDbConnectionDto.Port,
                        Database = testDbConnectionDto.Database,
                        User = testDbConnectionDto.User,
                        Password = testDbConnectionDto.Password
                    }
                };
                var jsonTestDbConnection = JsonConvert.SerializeObject(testDbConnectionRequest);
                var content = new StringContent(jsonTestDbConnection, Encoding.UTF8, MediaTypes.ApplicationJson);
                var requestUrl = AppUrlConstants.ConnectionUrl;
                
                var connectionResponse = await _httpClient.PostAsync(requestUrl, content);
                
                if (!connectionResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<TestDbConnectionResponse>()
                    {
                        Success = false,
                        //Result = connectionResponse,
                        ErrorMessage = $"Failed to test DataBase connection. Status code: {connectionResponse.StatusCode}"
                    };
                }
                var connectionResponseAsString = await connectionResponse.Content.ReadAsStringAsync();
                var connection = JsonConvert.DeserializeObject<TestDbConnectionResponse>(connectionResponseAsString);
                return new OperationResult<TestDbConnectionResponse>()
                {
                    Success = true,
                    Result = connection
                };

            }
            catch (Exception e)
            {
                return new OperationResult<TestDbConnectionResponse>()
                {
                    Success = false,
                    ErrorMessage = $"Failed to test DataBase connection with exception message:\n{e.Message}"
                };
            }
        }
        
        /// <summary>
        /// Get application info.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Utils/operation/utils-app-info
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult<GetAppInfoResponse>> GetAppInfo()
        {
            try
            {
               var appInfoUrl = AppUrlConstants.AppInfoUrl; 
                var appInfoResponse = await _httpClient.GetAsync(appInfoUrl);
                if (!appInfoResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<GetAppInfoResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to get App info. Status code: {appInfoResponse.StatusCode}",
                    };
                }
                var appInfoResponseAsString = await appInfoResponse.Content.ReadAsStringAsync();
                var appInfo = JsonConvert.DeserializeObject<GetAppInfoResponse>(appInfoResponseAsString);
                return new OperationResult<GetAppInfoResponse>()
                {
                    Success = true,
                    Result = appInfo
                };
            }
            catch (Exception e)
            {
                return new OperationResult<GetAppInfoResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
    }
}