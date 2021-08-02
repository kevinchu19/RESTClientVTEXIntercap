using RESTClientIntercapVTEX.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderDTO
    {
        public string orderId { get; set; }
        public string creationDate { get; set; }
        public IEnumerable<OrderItemsDTO> items { get; set; }
        public OrderShippingDataDTO shippingData { get; set; }
        public OrderClientProfileDataDTO clientProfileData { get; set; }
        public OrderPaymentDataDTO paymentData { get; set; }
        public IEnumerable<OrderTotalsDTO> totals { get; set; }

    }
}
