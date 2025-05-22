using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudModels.Contracts.Response
{
    public class WeatherReportResponse
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public double Temperature { get; set; }

        public double TempMin { get; set; }

        public double TempMax { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
