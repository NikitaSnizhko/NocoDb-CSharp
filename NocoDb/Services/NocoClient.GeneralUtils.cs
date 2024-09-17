using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NocoDb.Utils;
using Newtonsoft.Json;
using NocoDb.Models.GeneralNocoUtils;
using NocoDb.Models.GeneralNocoUtils.RequestParameters;
using NocoDb.Models.GeneralNocoUtils.Response;
using NocoDb.Models.GeneralNocoUtils.Request;

namespace NocoDb.Services
{
    public partial class NocoClient
    {
        /// <summary>
        /// Test if the database connection is available.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Utils/operation/utils-test-connection
        /// </summary>
        /// <param name="testDbConnectionParameters"></param>
        /// <returns></returns>
        public async Task<OperationResult<TestDbConnectionResponse>> TestDbConnection(TestDbConnectionParameters testDbConnectionParameters)
        {
            try
            {
                var testDbConnectionRequest = new TestDbConnectionRequest()
                {
                    Client = DbTypeHelper.GetDbTypeString(testDbConnectionParameters.Client),
                    Connection = new ConnectionData()
                    {
                        Host = testDbConnectionParameters.Host,
                        Port = testDbConnectionParameters.Port,
                        Database = testDbConnectionParameters.Database,
                        User = testDbConnectionParameters.User,
                        Password = testDbConnectionParameters.Password
                    }
                };
                var jsonTestDbConnection = JsonConvert.SerializeObject(testDbConnectionRequest);
                var content = new StringContent(jsonTestDbConnection, Encoding.UTF8, MediaTypes.ApplicationJson);
                var requestUrl = AppUrlConstants.ConnectionUrl;
                
                var connectionResponse = await httpClient.PostAsync(requestUrl, content);
                
                if (!connectionResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<TestDbConnectionResponse>()
                    {
                        Success = false,
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
                var appInfoResponse = await httpClient.GetAsync(appInfoUrl);
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