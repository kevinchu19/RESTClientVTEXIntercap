using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class ProductSpecificationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Value { get; set; }

        [JsonIgnore]
        public int ProductId { get; set; }
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
