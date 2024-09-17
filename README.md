# NocoDb-CSharp
This is a C# client for NocoDB API. It is a simple and easy-to-use library that allows you to interact with NocoDB API.
You can find official documentation for NocoDB API [here](https://meta-apis-v2.nocodb.com).
---
NOTE: This library based on **.NET Framework 4.8** and other versions of .NET will be added soon.

---
## How to use:

Initialize the client with the token and base URL of NocoDB instance.
```csharp
var Token = "Your_Token";
var BaseUrl = "https://NOCO.EXAMPLE.com";//Domain of your NocoDB instance.
var nocoClientOptions = new NocoClientOptions(Token, BaseUrl);
var nocoClientBuilder = new NocoClientBuilder(nocoClientOptions);
var nocoClient = nocoClientBuilder.Build();
```
Then we can use the client to interact with NocoDB API.
Here are list of what is currently implemented:

### General Utils:

#### Test connection to the database:
```csharp
var testDbConnectionDto = new TestDbConnectionDto(
DbType.Mysql2,
"localhost",
"3306",
"root",
"password",
null);
var testDbConnectionResult = await nocoClient.TestDbConnection(testDbConnectionDto);
Console.WriteLine(!testDbConnectionResult.Success
? testDbConnectionResult.ErrorMessage
: $"Connection successful:\n{testDbConnectionResult.Result.Data}");
```

#### Get app info:
```csharp
var getAppInfoResult = await nocoClient.GetAppInfo();
Console.WriteLine
(!getAppInfoResult.Success
? getAppInfoResult.ErrorMessage
: $"App info:\n{getAppInfoResult.Result.Type}");
```

### Databases methods:
#### Get base info:
```csharp
var databaseId = "Some_Base_Id";
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
}
```
   
#### Get all bases:
```csharp
var getAllBasesResult = await nocoClient.GetAllBases();
Console.WriteLine(!getAllBasesResult.Success
                ? getAllBasesResult.ErrorMessage
                : $"Number of bases: {getAllBasesResult.Result.List.Length}");
```

#### Create a new base:
```csharp
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
}
```

#### Get base by id:
```csharp
var databaseId = "Some_Base_Id";
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
}
```

#### Delete base by id:
```csharp
var baseId = "some_Base_Id";
var deleteBaseResult = await nocoClient.DeleteBase(baseId);
Console.WriteLine(deleteBaseResult.Success
    ? "Base deleted"
    : deleteBaseResult.ErrorMessage);
```

#### Update base by id:
```csharp
var baseId = "some_Base_Id";
var updateBaseDto = new UpdateBaseDto(baseId)
{
    //These are optional. You can update only the fields you want.
    Title = "Base for update_ " + DateTime.Now,
    Color = "#24716E",
    Order = 1,
    Status = "active",
    Meta = null
};
var updateBaseResult = await nocoClient.UpdateBase(updateBaseDto);
Console.WriteLine(updateBaseResult.Success
    ? "Base updated"
    : updateBaseResult.ErrorMessage);
```


#### Duplicate base by id:
```csharp
var baseId = "some_Base_Id";
var duplicateBaseDto = new DuplicateBaseDto(    
    baseId: baseId,
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
}
```

### Tables methods:
#### Get all tables in base:
```csharp
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
}
```