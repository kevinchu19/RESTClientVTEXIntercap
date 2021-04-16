using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Sttgsh
    {
        public string Usr_Sttgsh_Deptos { get; set; }
        public string Usr_Sttgsh_Catego { get; set; }
        public string Usr_Sttgsh_Subcat { get; set; }
        public string Usr_Sttgsh_Nombre { get; set; }
        public int? Usr_Sttgsh_Idvtex { get; set; }
        public int? Usr_Sttgsh_Positi { get; set; }
        public DateTime? Usr_St_Fecalt { get; set; }
        public DateTime? Usr_St_Fecmod { get; set; }
        public string Usr_St_Userid { get; set; }
        public string Usr_St_Ultopr { get; set; }
        public string Usr_St_Debaja { get; set; }
        public string Usr_St_Oalias { get; set; }
        public string Usr_Vtex_Transf { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int RowId { get; set; }
    }
}
