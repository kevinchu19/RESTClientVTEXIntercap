using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class InventoryDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public string Stmpdh_Tippro { get; set; }

        [JsonIgnore]
        public string Stmpdh_Artcod { get; set; }

    }
}
