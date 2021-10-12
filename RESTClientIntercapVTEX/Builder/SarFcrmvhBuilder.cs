using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTClientIntercapVTEX.Builder
{
    public class SarFcrmvhBuilder: IBuilder<Sar_Fcrmvh>
    {

        private string Sar_Fcrmvh_Identi { get; set; }
        private string Sar_Fcrmvh_Status { get; set; }
        private string Sar_Fcrmvh_Nrocta { get; set; }
        private DateTime? Sar_Fcrmvh_Fchmov { get; set; }
        private string Sar_Fcrmvh_Circom { get; set; }
        private string Sar_Fcrmvh_Cirapl { get; set; }
        private string Sar_Fcrmvh_Codemp { get; set; }
        private string Sar_Fcrmvh_Modfor { get; set; }
        private string Sar_Fcrmvh_Codfor { get; set; }
        
        private readonly List<Sar_Fcrmvi> Items = new List<Sar_Fcrmvi>();
        
        public SarFcrmvhBuilder()
        {
        }

        public SarFcrmvhBuilder setHeader(OrderDTO orderHeader)
        {
            Sar_Fcrmvh_Identi = orderHeader.orderId;
            Sar_Fcrmvh_Status = "N";
            Sar_Fcrmvh_Nrocta = "004333";
            Sar_Fcrmvh_Fchmov = Convert.ToDateTime(orderHeader.creationDate);
            Sar_Fcrmvh_Circom = "0220";
            Sar_Fcrmvh_Cirapl = "0220";
            Sar_Fcrmvh_Codemp = "TEM";
            Sar_Fcrmvh_Modfor = "FC";
            Sar_Fcrmvh_Codfor = "NPVTEX";             
            return this;
        }

        public SarFcrmvhBuilder addItems(string orderId,IEnumerable<OrderItemsDTO> orderItems, OrderShippingDataDTO orderShippingData)
        {
            foreach (var orderItem in orderItems.Select((value, i) => new { i, value }))
            {
                OrderItemsDTO item = orderItem.value;
                Items.Add(new Sar_Fcrmvi()
                {
                    //Sar_Fcrmvi_Identi = orderId,
                    Sar_Fcrmvi_Nroitm = orderItem.i+1,
                    Sar_Fcrmvi_Tippro = item.refId.Substring(0, 3),
                    Sar_Fcrmvi_Artcod = item.refId.Substring(3, 9),
                    Sar_Fcrmvi_Cantid = item.quantity,
                    Sar_Fcrmvi_Precio = item.price,
                    Usr_Fcrmvi_Deposi = orderShippingData.logisticsInfo[orderItem.i].deliveryIds[0].warehouseId,
                    Usr_Fcrmvi_Sector = "0",
                    Usr_Fcrmvi_Selsla = orderShippingData.logisticsInfo[orderItem.i].selectedSla
                });
            }
            
            return this;
        }

        public Sar_Fcrmvh Build()
        {
            return new Sar_Fcrmvh(Sar_Fcrmvh_Identi,
                                    Sar_Fcrmvh_Status,
                                    Sar_Fcrmvh_Nrocta,
                                    Sar_Fcrmvh_Fchmov,
                                    Sar_Fcrmvh_Circom,
                                    Sar_Fcrmvh_Cirapl,
                                    Sar_Fcrmvh_Codemp,
                                    Sar_Fcrmvh_Modfor,
                                    Sar_Fcrmvh_Codfor,
                                    Items);
        }

    }
}
