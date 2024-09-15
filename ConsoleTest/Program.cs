using System;
using System.Threading.Tasks;
using NocoDb.Models.Bases.Dto;
using NocoDb.Models.GeneralNocoUtils;
using NocoDb.Models.GeneralNocoUtils.Dto;
using NocoDb.Services;

namespace ConsoleTest
{
    internal class Program
    {
        private static readonly string Token = Environment.GetEnvironmentVariable("NocoApiToken", EnvironmentVariableTarget.User);
        private static readonly string BaseUrl = Environment.GetEnvironmentVariable("NocoBaseUrl", EnvironmentVariableTarget.User);
        
        public static async Task Main(string[] args)
        {
            var nocoClientOptions = new NocoClientOptions(Token, BaseUrl);
            var nocoClientBuilder = new NocoClientBuilder(nocoClientOptions);
            var nocoClient = nocoClientBuilder.Build();
            
            /*// Test connection to the database  
            var testDbConnectionDto = new TestDbConnectionDto(
                DbType.Mysql2,
                "localhost",
                "3306",
                "root",
                "password",
                null
            );
            var testDbConnectionResult = await nocoClient.TestDbConnection(testDbConnectionDto);
            Console.WriteLine(!testDbConnectionResult.Success
                ? testDbConnectionResult.ErrorMessage
                : $"Connection successful:\n{testDbConnectionResult.Result.Data}");*/
            

            /*// Get app info
            var getAppInfoResult = await nocoClient.GetAppInfo();
            Console.WriteLine
                (!getAppInfoResult.Success
                        ? getAppInfoResult.ErrorMessage
                        : $"App info:\n{getAppInfoResult.Result.Type}"
                );*/
            
            
            /*//Get base info by id
            var databaseId = Environment.GetEnvironmentVariable("NocoInnerDbId", EnvironmentVariableTarget.User);
            var getBaseInfoResult = await nocoClient.GetBaseInfo(databaseId);
            if (!getBaseInfoResult.Success)
                Console.WriteLine(getBaseInfoResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Base info:\n" +
                                  $"Arch: {getBaseInfoResult.Result.Arch}\n" +
                                  $"Database: {getBaseInfoResult.Result.Database}\n" +
                                  $"Docker: {getBaseInfoResult.Result.Docker}\n" +
                                  $"Node: {getBaseInfoResult.Result.Node}\n" +
                                  $"PackageVersion: {getBaseInfoResult.Result.PackageVersion}\n");
            }*/
            
            
            /*// Get all bases
            var getAllBasesResult = await nocoClient.GetAllBases();
            Console.WriteLine(!getAllBasesResult.Success
                ? getAllBasesResult.ErrorMessage
                : $"Number of bases: {getAllBasesResult.Result.List.Length}");*/


            /*// Create a new base
            const string baseTitle = "TestBase";
            var createBaseDto = new CreateBaseDto(baseTitle)
            {
                //These are optional
                //Color = "#24716E",
                //Description = "This is a test base",
                //Order = 10,
                //Status = "active"
            };
            
            var createBaseResult = await nocoClient.CreateBase(createBaseDto);
            if (!createBaseResult.Success)
                Console.WriteLine(createBaseResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Base created:\n" +
                                  $"Color: {createBaseResult.Result.Color}\n" +
                                  $"CreatedAt: {createBaseResult.Result.CreatedAt}\n" +
                                  $"UpdatedAt: {createBaseResult.Result.UpdatedAt}\n" +
                                  $"Description: {createBaseResult.Result.Description}\n" +
                                  $"Id: {createBaseResult.Result.Id}\n" +
                                  $"IsMeta: {createBaseResult.Result.IsMeta}\n" +
                                  $"Order: {createBaseResult.Result.Order}\n" +
                                  $"Prefix: {createBaseResult.Result.Prefix}\n" +
                                  $"Status: {createBaseResult.Result.Status}\n" +
                                  $"Title: {createBaseResult.Result.Title}\n" +
                                  $"Uuid: {createBaseResult.Result.Uuid}\n" +
                                  $"Password: {createBaseResult.Result.Password}\n");
            }*/
            
            
            /*//Get base by id
            var databaseId = Environment.GetEnvironmentVariable("NocoInnerDbId", EnvironmentVariableTarget.User);
            var getBaseResult = await nocoClient.GetBase(databaseId);
            if (!getBaseResult.Success)
                Console.WriteLine(getBaseResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Base info:\n" +
                                  $"Color: {getBaseResult.Result.Color}\n" +
                                  $"CreatedAt: {getBaseResult.Result.CreatedAt}\n" +
                                  $"UpdatedAt: {getBaseResult.Result.UpdatedAt}\n" +
                                  $"Description: {getBaseResult.Result.Description}\n" +
                                  $"Id: {getBaseResult.Result.Id}\n" +
                                  $"IsMeta: {getBaseResult.Result.IsMeta}\n" +
                                  $"Order: {getBaseResult.Result.Order}\n" +
                                  $"Prefix: {getBaseResult.Result.Prefix}\n" +
                                  $"Status: {getBaseResult.Result.Status}\n" +
                                  $"Title: {getBaseResult.Result.Title}\n" +
                                  $"Uuid: {getBaseResult.Result.Uuid}\n" +
                                  $"Password: {getBaseResult.Result.Password}\n");
            }*/
            
            
            /*//Delete base by id
            var baseId = "some_Base_Id";
            var deleteBaseResult = await nocoClient.DeleteBase(baseId);
            Console.WriteLine(deleteBaseResult.Success
                ? "Base deleted"
                : deleteBaseResult.ErrorMessage);*/
            
            
            /*//Update base by id
            var baseId = "some_Base_Id";
            var updateBaseDto = new UpdateBaseDto(baseId)
            {
                //These are optional
                Title = "Base for update_ " + DateTime.Now, 
                Color = "#24716E",
                Order = 1,
                Status = "active",
                Meta = null
            };
            var updateBaseResult = await nocoClient.UpdateBase(updateBaseDto);
            Console.WriteLine(updateBaseResult.Success
                ? "Base updated"
                : updateBaseResult.ErrorMessage);*/
            
            
            /*//Duplicate base by id
            var baseId = "some_Base_Id";
            var duplicateBaseDto = new DuplicateBaseDto(
                baseId:baseId,
                excludeData: true,
                excludeHooks: true,
                excludeViews: true);
            var duplicateBaseResult = await nocoClient.DuplicateBase(duplicateBaseDto);
            if (!duplicateBaseResult.Success)
                Console.WriteLine(duplicateBaseResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Base duplicated:\n" +
                                  $"Id: {duplicateBaseResult.Result.Id}\n" +
                                  $"BaseId: {duplicateBaseResult.Result.BaseId}\n");
            }*/
        }
    }
}