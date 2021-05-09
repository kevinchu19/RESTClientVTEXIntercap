using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class SpecificationValueDTO
    {
        public int FieldValueId { get; set; }
        public int FieldId { get; set; }
        public string Name { get; set; }
        public string  Text { get; set; }
        public bool IsActive{ get; set; }
        public int Position{ get; set; }

        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        
        [JsonIgnore]
        public int RowId { get; set; }
    }
}
