using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Vtexha
    {
        public string Usr_Vtexha_Ordid { get; set; }
        public string Usr_Vtexha_Status { get; set; } = "N";
        public DateTime? Usr_Vt_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Usr_Vt_Fecmod { get; set; } = DateTime.Now;
        public string Usr_Vt_Userid { get; set; } = "API";
        public string Usr_Vt_Ultopr { get; set; } = "A";
        public string Usr_Vt_Debaja { get; set; } = "N";
        public string Usr_Vt_Oalias { get; set; } = "USR_VTEXHA";

    }
}
