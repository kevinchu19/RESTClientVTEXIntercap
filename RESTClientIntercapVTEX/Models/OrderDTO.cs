using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class OrderDTO
    {
        public string orderId { get; set; }
        public string creationDate { get; set; }
        public IEnumerable<OrderItemsDTO> items { get; set; }
        public OrderShippingDataDTO shippingData { get; set; }

    }
}
