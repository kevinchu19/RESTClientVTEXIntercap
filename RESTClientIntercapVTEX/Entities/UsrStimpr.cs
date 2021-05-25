using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Stimpr
    {
        public string Usr_Stimpr_Tippro { get; set; }
        public string  Usr_Stimpr_Artcod { get; set; }
        public int SKUId { get; set; }
        public short Usr_Stimpr_Orden { get; set; }
        public string Usr_Stimpr_Pathim { get; set; }
        public string Usr_Stimpr_Imggra { get; set; }
        public string Usr_Stimpr_Imgdps { get; set; }
        public string Usr_Stimpr_Imgtok { get; set; }

        public string Usr_Stimpr_Name { get; set; }
        public DateTime? Usr_St_Fecalt { get; set; }
        public DateTime? Usr_St_Fecmod { get; set; }
        public string Usr_St_Userid { get; set; }
        public string Usr_St_Ultopr { get; set; }
        public string Usr_St_Debaja { get; set; }
        public string Usr_St_Oalias { get; set; }
        public string Usr_Vtex_Transf { get; set; }
        public int? Usr_Stimpr_Idvtex { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int RowId { get; set; }
    }
}
