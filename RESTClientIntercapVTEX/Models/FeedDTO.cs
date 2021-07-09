using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class FeedDTO
    {
        public string EventId { get; set; }
        public string Handle { get; set; }
        public string Domain { get; set; }
        public string State { get; set; }
        public string LastState { get; set; }
        public string OrderId { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime CurrentChange { get; set; }
        public DateTime AvailableDate { get; set; }

    }
}
