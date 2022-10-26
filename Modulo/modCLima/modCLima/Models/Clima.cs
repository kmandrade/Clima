using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace modCLima.Models
{
    public class Clima
    {
        public string Name { get; set; }

        public Temp Temp { get; set; }

        public DateTime HoraAtual { get; set; }

    }
    public class Temp
    {
        public double temp_min { get; set; }
        public double temp_max { get; set; }

        public int? humidity { get; set; }
        public int? pressure { get; set; }

        public DateTime DateTime { get; set; }

    }
}