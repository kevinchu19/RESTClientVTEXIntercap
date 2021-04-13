using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Sttcai
    {
        public string Usr_Sttcai_Deptos { get; set; }
        public string Usr_Sttcai_Catego { get; set; }
        public string Usr_Sttcai_Descrp { get; set; }
        public string Usr_Sttcai_Keywor { get; set; }
        public string Usr_Sttcai_Descri { get; set; }
        public int Usr_Sttcai_Scores { get; set; }
        public string Usr_Sttcai_Isacti { get; set; }
        public DateTime? Usr_St_Fecalt { get; set; }
        public DateTime? Usr_St_Fecmod { get; set; }
        public string Usr_St_Userid { get; set; }
        public string Usr_St_Ultopr { get; set; }
        public string Usr_St_Debaja { get; set; }
        public string Usr_St_Oalias { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public string Usr_Vtex_Transf { get; set; }

        public int RowId { get; set; }
    }
}
