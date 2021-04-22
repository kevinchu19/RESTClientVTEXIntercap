using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class SkuDTOResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string RefId { get; set; }
        public decimal PackagedHeight { get; set; }
        public decimal PackagedLength { get; set; }
        public decimal PackagedWidth { get; set; }
        public decimal PackagedWeightKg { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal WeightKg { get; set; }
        public decimal CubicWeight { get; set; }
        public bool IsKit { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal RewardValue { get; set; }
        public DateTime EstimatedDateArrival { get; set; }
        public string ManufacturerCode { get; set; }
        public int CommercialConditionId { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal UnitMultiplier { get; set; }
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

    }
}
