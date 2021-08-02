using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderTotalsDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal? value { get; set; }
    }
}
