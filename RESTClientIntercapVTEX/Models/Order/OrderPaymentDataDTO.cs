using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderPaymentDataDTO
    {
        public List<OrderPaymentTransactionsDTO> transactions { get; set; }
    }
}
