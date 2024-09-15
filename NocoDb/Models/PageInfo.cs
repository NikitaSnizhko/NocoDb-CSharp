using System.Text.Json.Serialization;

namespace NocoDb.Models
{
    public class PageInfo
    {
        [JsonPropertyName("totalRows")]
        public int TotalRows { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("isFirstPage")]
        public bool IsFirstPage { get; set; }

        [JsonPropertyName("isLastPage")]
        public bool IsLastPage { get; set; }
    }
}