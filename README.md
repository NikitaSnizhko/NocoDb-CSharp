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
var testDbConnectionParameters = new TestDbConnectionParameters(
DbType.Mysql2,
"localhost",
"3306",
"root",
"password",
null);
var testDbConnectionResult = await nocoClient.TestDbConnection(testDbConnectionParameters);
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

---

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
var updateBaseParameters = new UpdateBaseParameters(baseId)
{
    //These are optional. You can update only the fields you want.
    Title = "Base for update_ " + DateTime.Now,
    Color = "#24716E",
    Order = 1,
    Status = "active",
    Meta = null
};
var updateBaseResult = await nocoClient.UpdateBase(updateBaseParameters);
Console.WriteLine(updateBaseResult.Success
    ? "Base updated"
    : updateBaseResult.ErrorMessage);
```


#### Duplicate base by id:
```csharp
var baseId = "some_Base_Id";
var duplicateBaseParameters = new DuplicateBaseParameters(    
    baseId: baseId,
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
}
```

---

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

#### Create a new table in base:
This is an example of creating a simple empty table:
```csharp
const string databaseId = "some_Base_Id";
const string tableName = "Users";
var newTableParameters = new CreateTableParameters(databaseId, tableName);
var createTableResult = await nocoClient.CreateTable(newTableParameters);
if (createResult.Success)
    Console.WriteLine("Table created");
else
    Console.WriteLine(createResult.ErrorMessage);
```
    
    
It is possible to create a table with any number of custom columns. 
This is an example of creating a table with 4 custom columns:
```csharp
const string databaseId = "some_Base_Id";
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
            ColumnDefaultValue = "user@email.com"
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
}
```

#### Get table by id:
```csharp
const string tableId = "some_Table_Id";
var getTableResult = await nocoClient.GetTable(tableId);
if (!getTableResult.Success)
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
}
```

#### Update table:
```csharp
const string tableId = "some_Table_Id";
var updateTableParameters = new UpdateTableParameters(tableId)
{
    TableName = "New Users",
    Title = "New Users"
};
var updateTableResult = await nocoClient.UpdateTable(updateTableParameters);
Console.WriteLine(updateTableResult.Success ? "Table updated." : updateTableResult.ErrorMessage);
```


#### Delete table:
```csharp   
const string tableId = "some_Table_Id";
var deleteTableResult = await nocoClient.DeleteTable(tableId);
Console.WriteLine(deleteTableResult.Success ? "Table deleted." : deleteTableResult.ErrorMessage);
```

#### Duplicate table:
```csharp
const string tableId = "some_Table_Id";
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
}
```

---

### Records methods:

#### Get record in table:
There are two options to get a record in a table. Get it as a json string(as NocoDb server return)
or map it to custom type(if all fields are known).

In both options it is possible to get all fields or only specific fields
by specifying them in the `Fields` property of the `GetRecordParameters` object.
For all fields, leave the `Fields` property empty or skip it at all like this:
`var getRecordParameters = new GetRecordParameters(tableId, recordId);`

Initialize the `GetRecordParameters` object:
```csharp
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
```

1. [x] First option: as string
```csharp
var getRecordResult = await nocoClient.GetRecordAsString(getRecordParameters);
if (!getRecordResult.Success)
    Console.WriteLine(getRecordResult.ErrorMessage);
else
{
    Console.WriteLine($"Record:\n{getRecordResult.Result}");
}
```

2. [x] Second option: as custom type

Here it is necessary to create a class that will represent the record in the table.
This is the basic example of the class that represents the record in the table 
created above(see the example of creating a table with 4 custom columns):
```csharp
private class ExampleGetRecordResponseType : IRecordResponse
{
    //These fields custom for the record in the table.
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    
    //NOTE: Any attachments fields have to be a list of FileAttachmentResponse objects.
    public List<FileAttachmentResponse> Passport { get; set; }
    
    //These fields come from the IRecordResponse interface.
    public string Id { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}
```
This class inherits from the `IRecordResponse` interface. It ensures that a few important fields,
which are always present in the record response, are included.

It is not mandatory to inherit from this interface (and it is recommended not to inherit if you use a custom "ID" field). 
In such cases, you must manually add all necessary fields to the class.

Then we can get the record as a custom type:
```csharp
const string tableId = "some_Table_Id";
const string recordId = "some_Record_Id";
var getRecordParameters = new GetRecordParameters(tableId, recordId);

var getRecordAsTypeResult = await nocoClient.GetRecordAsType<ExampleGetRecordResponseType>(getRecordParameters);
if(getRecordAsTypeResult.Success)
{
    var record = getRecordAsTypeResult.Result;
    Console.WriteLine($"Record:\n" +
                      $"UserName: {record.UserName ?? "Not provided"}\n" +
                      $"Email: {record.Email ?? "Not provided"}\n" +
                      $"IsActive: {record.IsActive}\n" +
                      $"Passport: {(record.Passport == null ? "Not provided" : record.Passport.FirstOrDefault()?.File.fileName)}\n" +
                      $"CreatedAt: {record.CreatedAt  ?? "Not provided"}\n" +
                      $"UpdatedAt: {record.UpdatedAt  ?? "Not provided"}\n" +
                      $"Id: {record.Id ?? "Not provided"}\n");
}
else
    Console.WriteLine(getRecordAsTypeResult.ErrorMessage);
```

And the last thing you can do after got a response is to convert attachment somewhere
because the response contains only the file name and byte array.
Here is simple example how to achieve this:
```csharp
var attachment = record.Passport?.FirstOrDefault()?.File;
if (attachment != null)
{
    const string localFilePath = @"some\path\to\save\folder";
    var attachmentFilePath = Path.Combine(localFilePath, attachment.Value.fileName);
    File.WriteAllBytes(attachmentFilePath, attachment.Value.fileContent);
    Console.WriteLine($"Attachment file saved to: {attachmentFilePath}");
}
```


#### Create records in table:

First of all, it is necessary to create a class that will represent the record in the table.
Its fields must match the fields of the table. And db-related or autoincremented fields must be ignored.

There are some important notes about creating a class that represents the record in the table:
1. [x] DO NOT include server generated fields like Id, CreatedAt, UpdatedAt, etc.  
2. [x] DO NOT include auto incremented fields.
3. [x] Use json property attribute to map the class properties to the table columns.
4. [x] Use the `List<FileAttachmentRequest>` type from `NocoDb.Models.Records.Request` for attachments fields.
5. [x] Be very careful with the "**_required_**" fields. In the current case, the UserName is required so
if it is not initialized in the future it will throw an exception. 
So it is mandatory to initialize it by default here or later in class instances.
```csharp
private class ExampleCreateRecordType
{
    [JsonProperty("UserName")]
    public string UserName { get; set; } = string.Empty;

    [JsonProperty("Email",
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("IsActive")]
    public bool IsActive { get; set; }

    [JsonProperty("Passport",
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<FileAttachmentRequest> Passport { get; set; }
}
```

If the field contains attachment so we can prepare data for attachment fields:
```csharp
const string tableId = "some_Table_Id";
const string attachmentFilePath = @"some\path\to\file.jpg";

var fileName = Path.GetFileName(attachmentFilePath);
var fileContent = File.ReadAllBytes(attachmentFilePath);

var passportAttachment = new FileAttachmentRequest(fileName, fileContent);
```

Then we can create a record in the table:
```csharp
var createRecordParameters = new CreateRecordsParameters<ExampleCreateRecordType>(tableId)
{
    //You have to provide at least one record. Max number of records are unknown.
    Records = new List<ExampleCreateRecordType>
    {
        //Example of a record with few attachments.
        new ExampleCreateRecordType()
        {
            UserName = "John Doe",
            Email = "example@email.com",
            IsActive = true,
            Passport = new List<FileAttachmentRequest>()
            {
                passportAttachment,
                passportAttachment,
                passportAttachment
            }
        },
        //Example of a record with one attachment.
        new ExampleCreateRecordType()
        {
            UserName = "Jane Doe",
            Email = "example-2@email.com",
            IsActive = false,
            Passport = new List<FileAttachmentRequest>()
            {
                passportAttachment
            }   
        },
        //Example of an empty record.
        new ExampleCreateRecordType()
    }
};

var createRecordResult = await nocoClient.CreateRecords(createRecordParameters);
if(!createRecordResult.Success)
    Console.WriteLine(createRecordResult.ErrorMessage);
else
{
    Console.WriteLine($"Records created:\n" +
                      $"Number of records: {createRecordResult.Result.Records.Count}\n" +
                      $"First record: {createRecordResult.Result.Records.FirstOrDefault()}");
}
```

