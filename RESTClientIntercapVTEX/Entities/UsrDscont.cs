using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Dscont
    {
        public string Usr_Dscont_DspemlId { get; set; }
        public string Usr_Dscont_Id { get; set; }
        public string Usr_Dscont_Name { get; set; }
        public string Usr_Dscont_Person { get; set; }
        public string Usr_Dscont_Mail { get; set; }
        public string Usr_Dscont_Phonen { get; set; }
        public string Usr_Dscont_Taxid { get; set; }
        public string Usr_Dscont_Stretn { get; set; }
        public string Usr_Dscont_Strenu { get; set; }
        public string Usr_Dscont_Addnot { get; set; }
        public string Usr_Dscont_State { get; set; }
        public string Usr_Dscont_City { get; set; }
        public string Usr_Dscont_Zipcod { get; set; }
        public string Usr_Dscont_Type { get; set; }
        public string Usr_Dscont_Proapp { get; set; }
        public string Usr_Dscont_Proini { get; set; }
        public string Usr_Dscont_Tipdoc { get; set; }
        public string Usr_Dscont_Nrodoc { get; set; }
        public string Usr_Dscont_Cndiva { get; set; }
        public DateTime? Usr_Ds_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Usr_Ds_Fecmod { get; set; } = DateTime.Now;
        public string Usr_Ds_Userid { get; set; } = "API";
        public string Usr_Ds_Ultopr { get; set; } = "A";
        public string Usr_Ds_Debaja { get; set; } = "N";
        public string Usr_Ds_Oalias { get; set; } = "USR_DSCONT";

        

        public virtual Usr_Dspeml Header { get; set; }
    }
}
