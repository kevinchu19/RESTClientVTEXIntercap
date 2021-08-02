using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Dsship
    {
        public string Usr_Dsship_DspemlId { get; set; }
        public string Usr_Dsship_Trackn { get; set; }
        public string Usr_Dsship_Courie { get; set; }
        public string Usr_Dsship_Traurl { get; set; }
        public string Usr_Dsship_Lblurl { get; set; }
        public DateTime? Usr_Ds_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Usr_Ds_Fecmod { get; set; } = DateTime.Now;
        public string Usr_Ds_Userid { get; set; } = "API";
        public string Usr_Ds_Ultopr { get; set; } = "A";
        public string Usr_Ds_Debaja { get; set; } = "N";
        public string Usr_Ds_Oalias { get; set; } = "USR_DSSHIP";
        public virtual Usr_Dspeml Header { get; set; }
    }
}
