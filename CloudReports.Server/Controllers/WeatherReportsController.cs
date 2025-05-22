using CloudModels.Contracts.Response;
using CloudReports.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudReports.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherReportsController : ControllerBase
    {
        private readonly ILogger<WeatherReportsController> _logger;
        private readonly IReportsService _reportsService;

        public WeatherReportsController(ILogger<WeatherReportsController> logger, IReportsService reportsService)
        {
            _logger = logger;
            _reportsService = reportsService;
        }

        [HttpGet("logs")]
        public IEnumerable<RequestLogResponse> GetLogs()
        {
            return _reportsService.GetLogs().MapToRequestLogResponse();
        }

        [HttpGet("reports")]
        public IEnumerable<WeatherReportResponse> GetReports([FromQuery] int? lastHours, [FromQuery] string? date)
        {
            if (lastHours.HasValue)
            {
                return _reportsService.GetLastHoursReports(lastHours.Value).MapToWeatherReportResponse();
            }

            if (!string.IsNullOrEmpty(date))
            {
                return _reportsService.GetReportsForDate(date).MapToWeatherReportResponse();
            }

            return _reportsService.GetInitialReports().MapToWeatherReportResponse();
        }
    }
}
