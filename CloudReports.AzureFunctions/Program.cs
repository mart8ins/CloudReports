using CloudReports.DatabaseAccess;
using CloudReports.DatabaseAccess.Repository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContext<CloudReportsDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnection")));
        services.AddTransient<HttpClient>();
        services.AddTransient<IRepository, Repository>();
    })
    .Build();

host.Run();
