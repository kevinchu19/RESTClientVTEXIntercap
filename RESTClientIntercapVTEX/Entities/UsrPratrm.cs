using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Pratrm
    {
        public string Usr_Pratrm_Tippro { get; set; }
        public string Usr_Pratrm_Artcod { get; set; }
        public int Usr_Pratrm_Orden { get; set; }
        public string Usr_Pratrm_Campo { get; set; }
        public string Usr_Pratrm_Valor { get; set; }
        public DateTime? Usr_Pr_Fecalt { get; set; }
        public DateTime? Usr_Pr_Fecmod { get; set; }
        public string Usr_Pr_Userid { get; set; }
        public string Usr_Pr_Ultopr { get; set; }
        public string Usr_Pr_Debaja { get; set; }
        public string Usr_Vtex_Transf { get; set; }
        public int? Usr_Pratrm_Idvtex { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int RowId { get; set; }
    }

}
