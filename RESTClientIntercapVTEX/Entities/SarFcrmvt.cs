using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Sar_Fcrmvt
    {
        public string Sar_Fcrmvt_Identi { get; set; }
        public int Sar_Fcrmvt_Nroitm { get; set; }
        public double? Sar_Fcrmvt_Nroint { get; set; }
        public double? Sar_Fcrmvt_Cheque { get; set; }
        public short? Sar_Fcrmvt_Chesuc { get; set; }
        public string Sar_Fcrmvt_Codbco { get; set; }
        public string Sar_Fcrmvt_Catego { get; set; }
        public short? Sar_Fcrmvt_Clring { get; set; }
        public decimal? Sar_Fcrmvt_Import { get; set; }
        public decimal? Sar_Fcrmvt_Cambio { get; set; }
        public decimal? Sar_Fcrmvt_Impuss { get; set; }
        public string Sar_Fcrmvt_Docfir { get; set; }
        public DateTime? Sar_Fcrmvt_Fchvnc { get; set; }
        public string Sar_Fcrmvt_Tipcpt { get; set; }
        public string Sar_Fcrmvt_Codcpt { get; set; }
        public string Sar_Fcrmvt_Monext { get; set; }
        public string Sar_Fcrmvt_Textos { get; set; }
        public DateTime? Sar_Fc_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Sar_Fc_Fecmod { get; set; } = DateTime.Now;
        public string Sar_Fc_Userid { get; set; } = "API";
        public string Sar_Fc_Ultopr { get; set; } = "A";
        public string Sar_Fc_Debaja { get; set; } = "N";
        public string Sar_Fc_Oalias { get; set; } = "SAR_FCRMVT";
    }
}
