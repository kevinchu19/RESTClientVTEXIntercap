using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class MotosDocumentDTO
    {
        public string DocumentId { get; set; }
        public string idERP { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string version { get; set; }
        public string cilindrada{ get; set; }
        //public IEnumerable<int> anios { get; set; }
        public string anios { get; set; }
        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }

    }
}
