using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using CloudModels.Models.WeatherResponse;
using Newtonsoft.Json;
using CloudReports.DatabaseAccess.Repository;
using CloudReports.DatabaseAccess.Entities;

namespace CloudReports.AzureFunctions
{
    public class FetchWeatherFunction
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IRepository _repository;

        public FetchWeatherFunction(ILoggerFactory loggerFactory, HttpClient httpClient, IRepository repository)
        {
            _logger = loggerFactory.CreateLogger<FetchWeatherFunction>();
            _httpClient = new HttpClient();
            _repository = repository;
        }

        [Function("FetchWeatherFunction")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"FetchWeatherFunction execution starts: {DateTime.Now}");

            var weatherApiBaseUrl = Environment.GetEnvironmentVariable("weatherApiBaseUrl");
            var weatherApiKey = Environment.GetEnvironmentVariable("weatherApiKey");
            var cities = Environment.GetEnvironmentVariable("cities").Split(";");


            string fullUrl = string.Empty;
            HttpResponseMessage response;

            try
            {
                foreach (var city in cities)
                {
                    fullUrl = $"{weatherApiBaseUrl}/weather?q={city}&appid={weatherApiKey}";
                    _logger.LogInformation($"Fetching data for city {city}: {DateTime.Now}");

                    response = await _httpClient.GetAsync(fullUrl);

                    var requestLog = new RequestLog
                    {
                        StatusCode = (int)response.StatusCode,
                        IsSuccess = response.IsSuccessStatusCode,
                        RequestUrl = fullUrl,
                    };

                    if (response.IsSuccessStatusCode)
                    {
                        string rawJson = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(rawJson))
                        {
                            requestLog.ErrorMessage = $"Request for weather service was successful but without content.";
                            _logger.LogInformation($"Failed to fetch weather report for city {city}: {DateTime.Now}");
                            _repository.SaveRequestLog(requestLog);

                            continue;
                        }

                        WeatherResponse data = JsonConvert.DeserializeObject<WeatherResponse>(rawJson);

                        var weatherReport = new WeatherReport()
                        {
                            City = data.Name,
                            Country = data.Sys.Country,
                            Temperature = data.Main.Temp,
                            TempMax = data.Main.TempMax,
                            TempMin = data.Main.TempMin,
                            LastUpdateTime = DateTimeOffset.FromUnixTimeSeconds(data.Dt).UtcDateTime,
                            RawJson = rawJson,
                            RequestLog = requestLog
                        };

                        _repository.SaveReport(requestLog, weatherReport);

                        _logger.LogInformation($"Report for city {city} saved: {DateTime.Now}");
                    }
                    else
                    {
                        requestLog.ErrorMessage = $"Failed to fetch weather report for city {city}.";
                        _logger.LogInformation($"Failed to fetch weather report for city {city}: {DateTime.Now}");
                        _repository.SaveRequestLog(requestLog);
                    }

                }
            }
            catch (Exception ex)
            {
                var requestLog = new RequestLog
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    ErrorMessage = $"{ex.Message}",
                    RequestUrl = fullUrl,
                };

                _repository.SaveRequestLog(requestLog);
                _logger.LogError($"Error while fetching weather report. Message - {ex.Message}: {DateTime.Now}");
            }
        }
    }
}
