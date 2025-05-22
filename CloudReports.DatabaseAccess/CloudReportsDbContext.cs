using CloudReports.DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudReports.DatabaseAccess
{
    public class CloudReportsDbContext: DbContext
    {
        public CloudReportsDbContext(DbContextOptions<CloudReportsDbContext> options) : base(options) { }

        public DbSet<WeatherReport> WeatherReport { get; set; }
        public DbSet<RequestLog> RequestLog { get; set; }

    }
}
