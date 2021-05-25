using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class PricesDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        //public int markup { get; set; }
        public double listPrice { get; set; }
        public double basePrice { get; set; }
        //public float costPrice { get; set; }

        [JsonIgnore]
        public string Stmpdh_Tippro { get; set; }

        [JsonIgnore]
        public string Stmpdh_Artcod { get; set; }

    }
}
