using CloudReports.DatabaseAccess.Entities;
using CloudReports.DatabaseAccess.Repository;

namespace CloudReports.Server.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IRepository _repository;

        public ReportsService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RequestLog> GetLogs()
        {
            return _repository.GetLogs();
        }

        public IEnumerable<WeatherReport> GetInitialReports()
        {
            return _repository.GetInitialReports();
        }

        public IEnumerable<WeatherReport> GetLastHoursReports(int lastHours)
        {
            var timeCutOff = DateTime.Now.AddHours(-lastHours);

            return _repository.GetLastHoursReports(timeCutOff);
        }

        public IEnumerable<WeatherReport> GetReportsForDate(string date)
        {
            DateTime filterDate = DateTime.Parse(date);

            return _repository.GetReportsForDate(filterDate);
        }
    }
}
