﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models.Order
{
    public class OrderLogisticsInfoDTO
    {
        public int itemIndex { get; set; }
        public string selectedSla { get; set; }
        public List<OrderDeliveryIdsDTO> deliveryIds { get; set; }
    }
}
