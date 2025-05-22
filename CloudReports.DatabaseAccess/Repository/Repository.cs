using CloudReports.DatabaseAccess.Entities;

namespace CloudReports.DatabaseAccess.Repository
{
    public class Repository: IRepository
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CloudReportsDbContext _dbContext;

        public Repository(IServiceProvider serviceProvider, CloudReportsDbContext dbContext) 
        {
            _serviceProvider = serviceProvider;
            _dbContext = dbContext;
        }

        public void SaveReport(RequestLog requestLog, WeatherReport report)
        {
            _dbContext.RequestLog.Add(requestLog);
            _dbContext.WeatherReport.Add(report);
            _dbContext.SaveChanges();
        }

        public void SaveRequestLog(RequestLog requestLog)
        {
            _dbContext.RequestLog.Add(requestLog);
            _dbContext.SaveChanges();
        }

        public IEnumerable<RequestLog> GetLogs()
        {
            return _dbContext.RequestLog.OrderByDescending(x => x.Id).Take(100);
        }

        public IEnumerable<WeatherReport> GetInitialReports()
        {
            return _dbContext.WeatherReport
                 .GroupBy(w => w.City)
                 .Select(g => g.OrderByDescending(w => w.LastUpdateTime)
                 .FirstOrDefault());
        }

        public IEnumerable<WeatherReport> GetLastHoursReports(DateTime timeCutOff)
        {
            return _dbContext.WeatherReport
                 .Where(w => w.CreatedAt >= timeCutOff)
                 .GroupBy(w => w.City)
                 .ToList()
                 .Select(i => new WeatherReport
                 {
                     Id = i.Last().Id,
                     City = i.Key,
                     Country = i.Last().Country,
                     TempMin = i.Average(w => w.TempMin),
                     TempMax = i.Average(w => w.TempMax),
                     Temperature = i.Average(w => w.Temperature),
                     LastUpdateTime = i.Last().LastUpdateTime,
                     CreatedAt = i.Last().CreatedAt,
                     RawJson = i.Last().RawJson,
                     RequestId = i.Last().RequestId,
                     RequestLog = i.Last().RequestLog
                 });
        }

        public IEnumerable<WeatherReport> GetReportsForDate(DateTime date)
        {
            return _dbContext.WeatherReport
                 .Where(w => w.CreatedAt.Date == date.Date)
                 .GroupBy(w => w.City)
                 .ToList()
                 .Select(i => new WeatherReport
                 {
                     Id = i.Last().Id,
                     City = i.Key,
                     Country = i.Last().Country,
                     TempMin = i.Average(w => w.TempMin),
                     TempMax = i.Average(w => w.TempMax),
                     Temperature = i.Average(w => w.Temperature),
                     LastUpdateTime = i.Last().LastUpdateTime,
                     CreatedAt = i.Last().CreatedAt,
                     RawJson = i.Last().RawJson,
                     RequestId = i.Last().RequestId,
                     RequestLog = i.Last().RequestLog
                 });
        }
    }
}
