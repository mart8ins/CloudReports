using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudModels.Contracts.Response
{
    public class RequestLogResponse
    {
        public int Id { get; init; }
        public DateTimeOffset TimeStamp { get; init; }
        public string HttpMethod { get; init; }
        public int StatusCode { get; init; }
        public bool IsSuccess { get; init; }
        public string? ErrorMessage { get; init; }
        public required string RequestUrl { get; init; }
    }
}
