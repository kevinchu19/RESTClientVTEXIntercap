using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Dspaym
    {
        public string Usr_Dspaym_DspemlId { get; set; }
        public string Usr_Dspaym_Inteid { get; set; }
        public DateTime? Usr_Dspaym_Date { get; set; }
        public decimal? Usr_Dspaym_Amount { get; set; }
        public string Usr_Dspaym_Status { get; set; }
        public string Usr_Dspaym_Method { get; set; }
        public string Usr_Dspaym_Notes { get; set; }
        public decimal? Usr_Dspaym_Trafee { get; set; }
        public short? Usr_Dspaym_Instal { get; set; }
        public DateTime? Usr_Ds_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Usr_Ds_Fecmod { get; set; } = DateTime.Now;
        public string Usr_Ds_Userid { get; set; } = "API";
        public string Usr_Ds_Ultopr { get; set; } = "A";
        public string Usr_Ds_Debaja { get; set; } = "N";
        public string Usr_Ds_Oalias { get; set; } = "USR_DSPAYM";
        public virtual Usr_Dspeml Header { get; set; }
    }
}
