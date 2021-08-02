using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderPaymentDTO
    {
        public string id { get; set; }
        public decimal? value { get; set; }
        public string paymentSystem { get; set; }
        public string paymentSystemName { get; set; }

        public string cardHolder { get; set; }
        public string cardNumber { get; set; }
        public string firstDigits {get; set; }

        public string lastDigits { get; set; }
    }
}
