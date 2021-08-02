using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderAddressDTO
    {
        public string addressId { get; set; }
        public string receiverName { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string number { get; set; }
    }
}
