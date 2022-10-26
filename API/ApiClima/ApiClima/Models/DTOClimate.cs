using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClima.Models
{
    public class DTOClimate
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "main")]
        public DTOtemp Temp { get; set; }
    }
    public class DTOtemp
    {
        public double temp_min { get; set; }
        public double temp_max { get; set; }

        public int? humidity { get; set; }
        public int? pressure { get; set; }

        public DateTime DateTime { get; set; }
    }

}
