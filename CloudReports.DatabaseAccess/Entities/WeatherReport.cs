using System.ComponentModel.DataAnnotations.Schema;


namespace CloudReports.DatabaseAccess.Entities
{
    public class WeatherReport
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public double Temperature { get; set; }

        public double TempMin { get; set; }

        public double TempMax { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public DateTime CreatedAt { get; init; } = DateTime.Now;

        public string RawJson { get; set; }

        [ForeignKey("RequestLog")]
        public int RequestId { get; set; }

        public RequestLog RequestLog { get; set; }
    }
}
