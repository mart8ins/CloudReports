using CloudReports.DatabaseAccess.Entities;

namespace CloudReports.DatabaseAccess.Repository
{
    public interface IRepository
    {
        void SaveReport(RequestLog requestLog, WeatherReport report);
        void SaveRequestLog(RequestLog requestLog);
        IEnumerable<RequestLog> GetLogs();
        IEnumerable<WeatherReport> GetInitialReports();
        IEnumerable<WeatherReport> GetLastHoursReports(DateTime timeCutOff);
        IEnumerable<WeatherReport> GetReportsForDate(DateTime date);
    }
}
