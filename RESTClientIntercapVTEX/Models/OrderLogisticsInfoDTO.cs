using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class OrderLogisticsInfoDTO
    {
        public int itemIndex { get; set; }
        public List<OrderDeliveryIdsDTO> deliveryIds { get; set; }
    }
}
