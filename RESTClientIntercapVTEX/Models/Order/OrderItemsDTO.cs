using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderItemsDTO
    {
        public int quantity { get; set; }
        public string refId { get; set; }
        public decimal price { get; set; }

    }
}
