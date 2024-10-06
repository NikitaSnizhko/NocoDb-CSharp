namespace NocoDb.Models.Records.Response;

public interface IRecordResponse
{
    string Id { get; set; }
    string CreatedAt { get; set; }
    string UpdatedAt { get; set; }
}