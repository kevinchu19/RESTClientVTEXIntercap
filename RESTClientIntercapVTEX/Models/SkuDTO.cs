using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class SkuDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; } = false;
        public string Name { get; set; }
        public string RefId { get; set; }
        public decimal? PackagedHeight { get; set; } = 1;
        public decimal? PackagedLength { get; set; } = 1;
        public decimal? PackagedWidth { get; set; } = 1;
        public decimal? PackagedWeightKg { get; set; } = 1000;
        public decimal Height { get; set; } = 1;
        public decimal Length { get; set; } = 1;
        public decimal Width { get; set; } = 1;
        public decimal WeightKg { get; set; } = 1000;
        public bool IsKit { get; set; }
        public string RewardValue { get; set; } = null;
        public string ManufacturerCode { get; set; }
        public int CommercialConditionId { get; set; } = 1;
        public string MeasurementUnit { get; set; } = "un";
        public decimal UnitMultiplier { get; set; } = 1;
        public string ModalType { get; set; } 
        public bool KitItensSellApart { get; set; }
        public bool ActivateIfPossible { get; set; }



        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        [JsonIgnore]
        public string Usr_St_Oalias { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }

        [JsonIgnore]
        public string Stmpdh_Tippro { get; set; }

        [JsonIgnore]
        public string Stmpdh_Artcod { get; set; }

    }
}
