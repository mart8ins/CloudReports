using CloudReports.DatabaseAccess.Entities;

namespace CloudReports.Server.Services
{
    public interface IReportsService
    {
        IEnumerable<RequestLog> GetLogs();
        IEnumerable<WeatherReport> GetInitialReports();
        IEnumerable<WeatherReport> GetLastHoursReports(int lastHours);
        IEnumerable<WeatherReport> GetReportsForDate(string date);
    }
}
