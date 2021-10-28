using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class SKUFileDTO
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Label{ get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Url{ get; set; }
        public int ArchiveId { get; set; }

        [JsonIgnore]
        public int SKUId { get; set; }

        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }
        [JsonIgnore]
        public string Usr_Stimpr_Tippro { get; set; }

        [JsonIgnore]
        public string Usr_Stimpr_Artcod { get; set; }
        

    }
}
