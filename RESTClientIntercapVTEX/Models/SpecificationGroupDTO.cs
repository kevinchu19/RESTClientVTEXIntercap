using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class SpecificationGroupDTO
    {
        public int? CategoryId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

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
