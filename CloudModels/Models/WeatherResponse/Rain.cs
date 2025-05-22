using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudModels.Models.WeatherResponse
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double OneHour { get; set; }
    }
}
