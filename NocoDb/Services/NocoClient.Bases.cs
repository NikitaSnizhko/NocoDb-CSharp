using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NocoDb.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NocoDb.Extensions;
using NocoDb.Models.Bases;
using NocoDb.Models.Bases.RequestParameters;
using NocoDb.Models.Bases.Response;
using NocoDb.Models.Bases.Request;
using NocoDb.Models.GeneralNocoUtils;

namespace NocoDb.Services
{
    public partial class NocoClient 
    {
        /// <summary>
        /// Get database info of certain database.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-meta-get
        /// </summary>
        /// <param name="databaseId"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetBaseInfoResponse>> GetBaseInfo([NotNull]string databaseId)
        {
            try
            {
                var baseInfoUrl = DbUrlConstants.GetDbInfoUrl(databaseId);
                
                var baseInfoResponse = await httpClient.GetAsync(baseInfoUrl);
                if (!baseInfoResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<GetBaseInfoResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to get Base info. Status code: {baseInfoResponse.StatusCode}",
                    };
                }
                var baseInfoResponseAsString = await baseInfoResponse.Content.ReadAsStringAsync();
                var baseInfo = JsonConvert.DeserializeObject<GetBaseInfoResponse>(baseInfoResponseAsString);
                return new OperationResult<GetBaseInfoResponse>()
                {
                    Success = true,
                    Result = baseInfo
                };
            }
            catch (Exception e)
            {
                return new OperationResult<GetBaseInfoResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Get list of all databases.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-list
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult<ListBasesResponse>> GetAllBases()
        {
            try
            {
                var allBasesUrl = DbUrlConstants.ListBasesUrl;
                
                var allBasesResponse = await httpClient.GetAsync(allBasesUrl);
                if (!allBasesResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<ListBasesResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to get all Bases. Status code: {allBasesResponse.StatusCode}",
                    };
                }
                var allBasesResponseAsString = await allBasesResponse.Content.ReadAsStringAsync();
                var allBases = JsonConvert.DeserializeObject<ListBasesResponse>(allBasesResponseAsString);
                return new OperationResult<ListBasesResponse>()
                {
                    Success = true,
                    Result = allBases
                };
            }
            catch (Exception e)
            {
                return new OperationResult<ListBasesResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }


        /// <summary>
        /// Create a new database with the "Title" as a mandatory property and other properties as optional.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-create
        /// </summary>
        /// <param name="createBaseParameters">List of parameters to create a database.</param>
        /// <returns></returns>
        public async Task<OperationResult<CreateBaseResponse>> CreateBase(
            [NotNull]CreateBaseParameters createBaseParameters)
        {
            try
            {
                var createBaseRequest = new CreateBaseRequest()
                {
                    Title = createBaseParameters.Title,
                    
                    Color = !string.IsNullOrEmpty(createBaseParameters.Color) ? createBaseParameters.Color : string.Empty,
                    Description = !string.IsNullOrEmpty(createBaseParameters.Description) ? createBaseParameters.Description : string.Empty,
                    Order = createBaseParameters.Order,
                    Status = !string.IsNullOrEmpty(createBaseParameters.Status) ? createBaseParameters.Status : string.Empty,
                    
                    //These properties are not implemented because it seems they do not affect the base creation.
                    //So they just hardcoded to default values.
                    Sources =
                    [
                        new SourceModel()
                        {
                            Alias = string.Empty,
                            Config = null,
                            Enabled = true,
                            Id = string.Empty,
                            InflectionColumn = "camelize",
                            InflectionTable = "camelize",
                            IsMeta = true,
                            Order = "1",
                            BaseId = string.Empty,
                            Type = DbTypeHelper.GetDbTypeString(DbType.Mysql2),
                            UpdatedAt = string.Empty,
                            CreatedAt = string.Empty
                        }
                    ],
                    CreatedAt = string.Empty,
                    Deleted = false,
                    Id = string.Empty,
                    IsMeta = true,
                    Meta =  null,
                    Prefix = string.Empty,
                    Type = VisualDbTypeHelper.GetVisualDbTypeString(VisualDbType.Dashboard),
                    
                    //External have to be false otherwise it will throw an error.
                    External = false,
                };
                
                var createBaseRequestJson = JsonConvert.SerializeObject(createBaseRequest);
                const string createBaseUrl = DbUrlConstants.CreateBaseUrl;
                var httpContent = new StringContent(createBaseRequestJson, Encoding.UTF8, MediaTypes.ApplicationJson);
                var createBaseResponse = await httpClient.PostAsync(createBaseUrl, httpContent);
                if (!createBaseResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<CreateBaseResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to create Base. Status code: {createBaseResponse.StatusCode}",
                    };
                }
                var createBaseResponseAsString = await createBaseResponse.Content.ReadAsStringAsync();
                var createBase = JsonConvert.DeserializeObject<CreateBaseResponse>(createBaseResponseAsString);
                return new OperationResult<CreateBaseResponse>()
                {
                    Success = true,
                    Result = createBase
                };
            }
            catch (Exception e)
            {
                return new OperationResult<CreateBaseResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
        
        
        /// <summary>
        /// Get base data of certain database.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-read
        /// </summary>
        /// <param name="databaseId"></param>
        /// <returns></returns>
        public async Task<OperationResult<GetBaseResponse>> GetBase([NotNull]string databaseId)
        {
            try
            {
                var baseRequestUrl = DbUrlConstants.GetSingleDbUrl(databaseId);
                
                var baseResponse = await httpClient.GetAsync(baseRequestUrl);
                if (!baseResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<GetBaseResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to get Base data. Status code: {baseResponse.StatusCode}",
                    };
                }
                var baseResponseAsString = await baseResponse.Content.ReadAsStringAsync();
                var baseData = JsonConvert.DeserializeObject<GetBaseResponse>(baseResponseAsString);
                return new OperationResult<GetBaseResponse>()
                {
                    Success = true,
                    Result = baseData
                };
            }
            catch (Exception e)
            {
                return new OperationResult<GetBaseResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
        
        
        /// <summary>
        /// Delete certain database by its id.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-delete
        /// </summary>
        /// <param name="databaseId"></param>
        /// <returns>Result bool value.</returns>
        public async Task<OperationResult<bool>> DeleteBase([NotNull]string databaseId)
        {
            try
            {
                var deleteBaseUrl = DbUrlConstants.DeleteSingleDbUrl(databaseId);
                
                var deleteBaseResponse = await httpClient.DeleteAsync(deleteBaseUrl);
                if (!deleteBaseResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<bool>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to delete Base. Status code: {deleteBaseResponse.StatusCode}",
                        Result = false
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
                    ErrorMessage = e.Message,
                    Result = false
                };
            }
        }


        /// <summary>
        /// Update certain database with the provided properties.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-update
        /// </summary>
        /// <param name="updateBaseParameters">Parameters to pass for update.</param>
        /// <returns>Result bool value.</returns>
        public async Task<OperationResult<bool>> UpdateBase([NotNull]UpdateBaseParameters updateBaseParameters)
        {
            try
            {
                var updateBaseRequest = new UpdateBaseRequest()
                {
                    Title = updateBaseParameters.Title,
                    Color = updateBaseParameters.Color,
                    Order = updateBaseParameters.Order,
                    Status = updateBaseParameters.Status,
                    Meta = updateBaseParameters.Meta
                };
                //Here we are ensuring that the properties with null values are will not be serialized.
                //This is very important otherwise the empty values will override the existing values.
                var updateBaseRequestJson = JsonConvert.SerializeObject(updateBaseRequest, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
                var updateBaseUrl = DbUrlConstants.UpdateSingleDbUrl(updateBaseParameters.Id);
                var httpContent = new StringContent(updateBaseRequestJson, Encoding.UTF8, MediaTypes.ApplicationJson);
                var updateBaseResponse = await httpClient.PatchAsync(updateBaseUrl, httpContent);
                if (!updateBaseResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<bool>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to update Base. Status code: {updateBaseResponse.StatusCode}",
                        Result = false
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
                    ErrorMessage = e.Message,
                    Result = false
                };

            }
        }

        
        /// <summary>
        /// Duplicate certain database by its id.
        /// Official API ref: https://meta-apis-v2.nocodb.com/#tag/Base/operation/base-duplicate
        /// </summary>
        /// <param name="duplicateBaseParameters">Parameters to pass for duplicate.</param>
        /// <returns></returns>
        public async Task<OperationResult<DuplicateBaseResponse>> DuplicateBase(
            [NotNull] DuplicateBaseParameters duplicateBaseParameters)
        {
            try
            {
                var duplicateBaseRequest = new DuplicateBaseRequest()
                {
                    ExcludeData = duplicateBaseParameters.ExcludeData,
                    ExcludeHooks = duplicateBaseParameters.ExcludeHooks,
                    ExcludeViews = duplicateBaseParameters.ExcludeViews
                };
                var duplicateBaseRequestJson = JsonConvert.SerializeObject(duplicateBaseRequest);
                var duplicateBaseUrl = DbUrlConstants.DuplicateSingleDbUrl(duplicateBaseParameters.BaseId);
                var httpContent = new StringContent(duplicateBaseRequestJson, Encoding.UTF8, MediaTypes.ApplicationJson);
                var duplicateBaseResponse = await httpClient.PostAsync(duplicateBaseUrl, httpContent);
                if (!duplicateBaseResponse.IsSuccessStatusCode)
                {
                    return new OperationResult<DuplicateBaseResponse>()
                    {
                        Success = false,
                        ErrorMessage = $"Failed to duplicate Base. Status code: {duplicateBaseResponse.StatusCode}",
                    };
                }
                var duplicateBaseResponseAsString = await duplicateBaseResponse.Content.ReadAsStringAsync();
                var duplicatedBase = JsonConvert.DeserializeObject<DuplicateBaseResponse>(duplicateBaseResponseAsString);
                return new OperationResult<DuplicateBaseResponse>()
                {
                    Success = true,
                    Result = duplicatedBase
                };
            }
            catch (Exception e)
            {
                return new OperationResult<DuplicateBaseResponse>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                };
            }
        }
    }
}