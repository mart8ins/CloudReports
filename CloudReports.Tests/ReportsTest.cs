using CloudReports.DatabaseAccess.Entities;
using CloudReports.Server;
using CloudReports.Server.Controllers;
using CloudReports.Server.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace CloudReports.Tests
{
    public class ReportsTest
    {
        [Fact]
        public void GetLogs_Test()
        {
            // Arrange
            List<RequestLog> requestLogs = new() { };
            var logger = new Mock<ILogger<WeatherReportsController>>();
            var mockService = new Mock<IReportsService>();
            mockService.Setup(x => x.GetLogs()).Returns(requestLogs);
            var controller = new WeatherReportsController(logger.Object, mockService.Object);

            // Act
            var result = controller.GetLogs();

            // Assert
            var expected = requestLogs.MapToRequestLogResponse();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetInitialReports_Test()
        {
            // Arrange
            List<WeatherReport> weatherReport = new() { };
            var logger = new Mock<ILogger<WeatherReportsController>>();
            var mockService = new Mock<IReportsService>();
            mockService.Setup(x => x.GetInitialReports()).Returns(weatherReport);
            var controller = new WeatherReportsController(logger.Object, mockService.Object);

            // Act
            var result = controller.GetReports(null, null);

            // Assert
            var expected = weatherReport.MapToWeatherReportResponse();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetLastHoursReports_Test()
        {
            // Arrange
            int hourMinus = 1;
            List<WeatherReport> weatherReport = new() { };
            var logger = new Mock<ILogger<WeatherReportsController>>();
            var mockService = new Mock<IReportsService>();
            mockService.Setup(x => x.GetLastHoursReports(hourMinus)).Returns(weatherReport);
            var controller = new WeatherReportsController(logger.Object, mockService.Object);

            // Act
            var result = controller.GetReports(hourMinus, null);

            // Assert
            var expected = weatherReport.MapToWeatherReportResponse();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetReportsForDate_Test()
        {
            // Arrange
            string date = "26-05-2025";
            List<WeatherReport> weatherReport = new() { };
            var logger = new Mock<ILogger<WeatherReportsController>>();
            var mockService = new Mock<IReportsService>();
            mockService.Setup(x => x.GetReportsForDate(date)).Returns(weatherReport);
            var controller = new WeatherReportsController(logger.Object, mockService.Object);

            // Act
            var result = controller.GetReports(null, date);

            // Assert
            var expected = weatherReport.MapToWeatherReportResponse();
            result.Should().BeEquivalentTo(expected);
        }
    }
}