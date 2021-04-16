using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Sttmah
    {
        public int Usr_Sttmah_Codigo { get; set; }
        public string Usr_Sttmah_Descrp { get; set; }
        public string Usr_Sttmah_Keywor { get; set; }
        public string Usr_Sttmah_Textos { get; set; }
        public string Usr_Sttmah_Sittit { get; set; }
        public int? Usr_Sttmah_Scores { get; set; }
        public string Usr_Sttmah_Menhom { get; set; }
        public string Usr_Vtex_Transf { get; set; }
        public DateTime? Usr_St_Fecalt { get; set; }
        public DateTime? Usr_St_Fecmod { get; set; }
        public string Usr_St_Userid { get; set; }
        public string Usr_St_Ultopr { get; set; }
        public string Usr_St_Debaja { get; set; }
        public string Usr_St_Oalias { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int RowId { get; set; }
    }
}
