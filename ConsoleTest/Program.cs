using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NocoDb.Models.Bases.RequestParameters;
using NocoDb.Models.GeneralNocoUtils;
using NocoDb.Models.GeneralNocoUtils.RequestParameters;
using NocoDb.Models.Records;
using NocoDb.Models.Records.RequestParameters;
using NocoDb.Models.Records.Response;
using NocoDb.Models.Tables;
using NocoDb.Models.Tables.RequestParameters;
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
            var testDbConnectionDto = new TestDbConnectionParameters(
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
            var databaseId = "some_Base_Id";
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
            var createBaseParameters = new CreateBaseParameters(baseTitle)
            {
                //These are optional
                //Color = "#24716E",
                //Description = "This is a test base",
                //Order = 10,
                //Status = "active"
            };
            
            var createBaseResult = await nocoClient.CreateBase(createBaseParameters);
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
            var updateBaseParameters = new UpdateBaseParameters(baseId)
            {
                //These are optional
                Title = "Base for update_ " + DateTime.Now, 
                Color = "#24716E",
                Order = 1,
                Status = "active",
                Meta = null
            };
            var updateBaseResult = await nocoClient.UpdateBase(updateBaseParameters);
            Console.WriteLine(updateBaseResult.Success
                ? "Base updated"
                : updateBaseResult.ErrorMessage);*/
            
            
            /*//Duplicate base by id
            var baseId = "some_Base_Id";
            var duplicateBaseParameters = new DuplicateBaseParameters(
                baseId:baseId,
                excludeData: true,
                excludeHooks: true,
                excludeViews: true);
            var duplicateBaseResult = await nocoClient.DuplicateBase(duplicateBaseParameters);
            if (!duplicateBaseResult.Success)
                Console.WriteLine(duplicateBaseResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Base duplicated:\n" +
                                  $"Id: {duplicateBaseResult.Result.Id}\n" +
                                  $"BaseId: {duplicateBaseResult.Result.BaseId}\n");
            }*/

            #region Get all tables in base
            /*//Get all tables in base
            const string databaseId = "some_Base_Id";
            var getAllTablesResult = await nocoClient.GetAllTablesInBase(databaseId);
            if (!getAllTablesResult.Success)
                Console.WriteLine(getAllTablesResult.ErrorMessage);
            else
            {
                var tablesString = new StringBuilder();
                tablesString.AppendLine($"Tables number:{getAllTablesResult.Result.Tables.Count}");
                tablesString.AppendLine();
                foreach (var table in getAllTablesResult.Result.Tables)
                {
                    tablesString.AppendLine($"Table info:\n" +
                                            $"BaseId: {table.BaseId}\n" +
                                            $"CreatedAt: {table.CreatedAt}\n" +
                                            $"Description: {table.Description}\n" +
                                            $"Enabled: {table.Enabled}\n" +
                                            $"Id: {table.Id}\n" +
                                            $"Mm: {table.Mm}\n" +
                                            $"Meta: {table.Meta}\n" +
                                            $"Order: {table.Order}\n" +
                                            $"Pinned: {table.Pinned}\n" +
                                            $"Schema: {table.Schema}\n" +
                                            $"SourceId: {table.SourceId}\n" +
                                            $"TableName: {table.TableName}\n" +
                                            $"Tags: {table.Tags}\n" +
                                            $"Title: {table.Title}\n" +
                                            $"Type: {table.Type}\n" +
                                            $"UpdatedAt: {table.UpdatedAt}\n");
                    tablesString.AppendLine();
                }
                Console.WriteLine(tablesString);
            }*/
            #endregion

            #region Create a new table
            //1) Simple empty table:
            /*const string databaseId = "some_Base_Id";
            const string tableName = "Users";
            var newTableParameters = new CreateTableParameters(databaseId, tableName);
            var createTableResult = await nocoClient.CreateTable(newTableParameters);
            Console.WriteLine(createTableResult.Success ? "Table created" : createTableResult.ErrorMessage);*/

            //2) Table with columns:
            /*const string databaseId = "some_Base_Id";
            const string tableName = "Users";
            var newTableParameters = new CreateTableParameters(databaseId, tableName)
            {
                TableTitle = tableName,
                ColumnsData = new List<CreateColumnParameters>()
                {
                    new CreateColumnParameters("UserName", ColumnDataType.SingleLineText)
                    {
                        Title = "UserName",
                        IsAutoIncremented = false,
                        ColumnDefaultValue = "Full Name",
                        IsRequired = true,
                        IsColumnUnique = false
                    },
                    new CreateColumnParameters("Email", ColumnDataType.Email)
                    {
                        Title = "Email",
                        ColumnDefaultValue = "user@mail.com"
                    },
                    new CreateColumnParameters("IsActive", ColumnDataType.Checkbox)
                    {
                        Title = "IsActive",
                        ColumnDefaultValue = true
                    },
                    new CreateColumnParameters("Passport", ColumnDataType.Attachment)
                    {
                        Title = "Passport",
                        ColumnDefaultValue = null,
                    }
                }
            };
            var createTableResult = await nocoClient.CreateTable(newTableParameters);
            if (!createTableResult.Success)
                Console.WriteLine(createTableResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Table created:\n" +
                                  $"BaseId: {createTableResult.Result.BaseId}\n" +
                                  $"CreatedAt: {createTableResult.Result.CreatedAt}\n" +
                                  $"Description: {createTableResult.Result.Description}\n" +
                                  $"Enabled: {createTableResult.Result.Enabled}\n" +
                                  $"Id: {createTableResult.Result.Id}\n" +
                                  $"Mm: {createTableResult.Result.Mm}\n" +
                                  $"Meta: {createTableResult.Result.Meta}\n" +
                                  $"Order: {createTableResult.Result.Order}\n" +
                                  $"Pinned: {createTableResult.Result.Pinned}\n" +
                                  $"Schema: {createTableResult.Result.Schema}\n" +
                                  $"SourceId: {createTableResult.Result.SourceId}\n" +
                                  $"TableName: {createTableResult.Result.TableName}\n" +
                                  $"Tags: {createTableResult.Result.Tags}\n" +
                                  $"Title: {createTableResult.Result.Title}\n" +
                                  $"Type: {createTableResult.Result.Type}\n" +
                                  $"UpdatedAt: {createTableResult.Result.UpdatedAt}\n");
            }*/
            #endregion

            #region Get table by id.
            /*const string tableId = "some_Table_Id";
            var getTableResult = await nocoClient.GetTable(tableId);
            if(!getTableResult.Success)
                Console.WriteLine(getTableResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Table info:\n" +
                                  $"BaseId: {getTableResult.Result.BaseId}\n" +
                                  $"CreatedAt: {getTableResult.Result.CreatedAt}\n" +
                                  $"Description: {getTableResult.Result.Description}\n" +
                                  $"Enabled: {getTableResult.Result.Enabled}\n" +
                                  $"Id: {getTableResult.Result.Id}\n" +
                                  $"Mm: {getTableResult.Result.Mm}\n" +
                                  $"Meta: {getTableResult.Result.Meta}\n" +
                                  $"Order: {getTableResult.Result.Order}\n" +
                                  $"Pinned: {getTableResult.Result.Pinned}\n" +
                                  $"Schema: {getTableResult.Result.Schema}\n" +
                                  $"SourceId: {getTableResult.Result.SourceId}\n" +
                                  $"TableName: {getTableResult.Result.TableName}\n" +
                                  $"Tags: {getTableResult.Result.Tags}\n" +
                                  $"Title: {getTableResult.Result.Title}\n" +
                                  $"Type: {getTableResult.Result.Type}\n" +
                                  $"UpdatedAt: {getTableResult.Result.UpdatedAt}\n");
            }*/
            #endregion
            
            #region Update table by id
            /*const string tableId = "some_Table_Id";
            var updateTableParameters = new UpdateTableParameters(tableId)
            {
                TableName = "New Users",
                Title = "New Users"
            };
            var updateTableResult = await nocoClient.UpdateTable(updateTableParameters);
            Console.WriteLine(updateTableResult.Success ? "Table updated." : updateTableResult.ErrorMessage);*/
            #endregion
            
            #region Delete table by id
            /*const string tableId = "some_Table_Id";
            var deleteTableResult = await nocoClient.DeleteTable(tableId);
            Console.WriteLine(deleteTableResult.Success ? "Table deleted." : deleteTableResult.ErrorMessage);*/
            #endregion
            
            #region Duplicate table by id
            /*const string tableId = "some_Table_Id";
            const string baseId = "some_Base_Id";
            var duplicateTableParameters = new DuplicateTableParameters(baseId, tableId)
            {
                //These are optional
                ExcludeData = true,
                ExcludeViews = true
            };
            var duplicateTableResult = await nocoClient.DuplicateTable(duplicateTableParameters);
            if (!duplicateTableResult.Success)
                Console.WriteLine(duplicateTableResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Table duplicated:\n" +
                                  $"Id: {duplicateTableResult.Result.Id}");
            }*/
            #endregion
            
            #region Get single record by id
            //This is the first simple way to get a record and return it as a string (json).
            //You can later deserialize it to a class.
            const string tableId = "some_Table_Id";
            const string recordId = "some_Record_Id";
            var getRecordParameters = new GetRecordParameters(tableId, recordId)
            {
                //Skip this if you want to get all fields.
                //These are optional. Use it if you want to get only specific fields.
                Fields = new List<string>()
                {
                    "UserName",
                    "Email"
                }
            };
            var getRecordResult = await nocoClient.GetRecordAsString(getRecordParameters);
            if (!getRecordResult.Success)
                Console.WriteLine(getRecordResult.ErrorMessage);
            else
            {
                Console.WriteLine($"Record:\n{getRecordResult.Result}");
            }
            
            //This is the second way to get a record and return it as a custom type.
            //Init the class you want to deserialize the record to and use it as a type parameter.
            
            var getRecordAsTypeResult = await nocoClient.GetRecordAsType<ExampleGetRecordResponseType>(getRecordParameters);
            if(getRecordAsTypeResult.Success)
            {
                var record = getRecordAsTypeResult.Result;
                Console.WriteLine($"Record:\n" +
                                  $"UserName: {record.UserName}\n" +
                                  $"Email: {record.Email}\n" +
                                  $"IsActive: {record.IsActive}\n" +
                                  $"Passport: {record.Passport.FirstOrDefault()?.Title}\n" +
                                  $"CreatedAt: {record.CreatedAt}\n" +
                                  $"UpdatedAt: {record.UpdatedAt}\n" +
                                  $"Id: {record.Id}\n");
            }
            else
                Console.WriteLine(getRecordAsTypeResult.ErrorMessage);
            #endregion
        }

        private class ExampleGetRecordResponseType : IRecordResponse
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public bool IsActive { get; set; }
            //For a files it is handy to use the Attachment type from NocoDb.Models.Records.Attachment.
            //NOTE: Any attachments fields have to be a list of Attachment objects.
            public List<NocoDb.Models.Records.Attachment> Passport { get; set; }
            public string Id { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }
        }
    }
}