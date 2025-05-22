
namespace CloudReports.DatabaseAccess.Entities
{
    public class RequestLog
    {
        public int Id { get; set; }
        public DateTimeOffset TimeStamp { get; init; } = DateTime.Now;
        public string HttpMethod { get; init; } = "GET";
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public required string RequestUrl { get; set; }
    }
}