using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Climate
    {
        [Key]
        [Required]
        public int IdClima { get; set; }

        public string NomeCidade { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<Temp> Temp { get; set; }



    }
    public class Temp
    {
        [Key]
        public int IdTemp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }

        public int? humidity { get; set; }

        public int? pressure { get; set; }

        public Climate? Climate { get; set; }
        public int? IdClima { get; set; }
    }
}
