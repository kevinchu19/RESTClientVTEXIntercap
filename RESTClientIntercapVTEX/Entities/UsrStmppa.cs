using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Stmppa
    {
        public string Usr_Stmppa_Indcod { get; set; }

        public int ProductId { get; set; }
        public int Usr_Stmppa_Orden { get; set; }
        public int Usr_Stmppa_Campo { get; set; }
        public int Usr_Stmppa_Valor { get; set; }
        public string Usr_Stmppa_Textos { get; set; }
        public DateTime? Usr_St_Fecalt { get; set; }
        public DateTime? Usr_St_Fecmod { get; set; }
        public string Usr_St_Userid { get; set; }
        public string Usr_St_Ultopr { get; set; }
        public string Usr_St_Debaja { get; set; }
        public string Usr_St_Oalias { get; set; }
        public string Usr_Vtex_Transf { get; set; }
        public int? Usr_Stmppa_Idvtex { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int RowId { get; set; }
    }

    }
