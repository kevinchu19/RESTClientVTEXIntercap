using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class SpecificationDTO
    {   
        public int Id { get; set; }
        public int FieldTypeId { get; set; }
        public int CategoryId { get; set; }
        public int FieldGroupId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public bool IsFilter { get; set; }
        public bool IsRequired { get; set; }
        public bool IsOnProductDetails { get; set; }
        public bool IsStockKeepingUnit { get; set; }
        public bool IsActive { get; set; }
        public bool IsTopMenuLinkActive { get; set; }
        public bool IsSideMenuLinkActive { get; set; }
        public string DefaultValue { get; set; }

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
