using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class OrderShippingDataDTO
    {
        public OrderAddressDTO address { get; set; }
        public List<OrderLogisticsInfoDTO> logisticsInfo { get; set; }

    }
}
