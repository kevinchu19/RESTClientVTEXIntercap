using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class SKUSpecificationDTO
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public int FieldValueId { get; set; }

        [JsonIgnore]
        public int SKUId { get; set; }

        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        
        [JsonIgnore]
        public int RowId { get; set; }
    }
}
