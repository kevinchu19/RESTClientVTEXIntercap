using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderPaymentTransactionsDTO
    {
        public bool isActive { get; set; }
        public string transactionId { get; set; }
        public List<OrderPaymentDTO> payments { get; set; }
    }
}
