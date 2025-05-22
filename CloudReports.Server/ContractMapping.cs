using CloudModels.Contracts.Response;
using CloudReports.DatabaseAccess.Entities;
using CloudReports.Server.Utils;

namespace CloudReports.Server
{
    public static class ContractMapping
    {
        public static IEnumerable<RequestLogResponse> MapToRequestLogResponse(this IEnumerable<RequestLog> requestLogs)
        {
            return requestLogs.Select(log => new RequestLogResponse
            {
                Id = log.Id,
                TimeStamp = log.TimeStamp,
                HttpMethod = log.HttpMethod,
                StatusCode = log.StatusCode,
                RequestUrl = log.RequestUrl,
                IsSuccess = log.IsSuccess,
                ErrorMessage = log.ErrorMessage
            });
        }

        public static IEnumerable<WeatherReportResponse> MapToWeatherReportResponse(this IEnumerable<WeatherReport> weatherReport)
        {
            return weatherReport.Select(report => new WeatherReportResponse
            {
                Id = report.Id,
                City = $"{report.City},{report.Country}",
                Temperature = TempConverter.KelvinToCelsius(report.Temperature),
                TempMax = TempConverter.KelvinToCelsius(report.TempMax),
                TempMin = TempConverter.KelvinToCelsius(report.TempMin),
                LastUpdateTime = report.LastUpdateTime,
                CreatedAt = report.CreatedAt
            });
        }
    }
}
