using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Sar_Fcrmvi
    {
        
        public string Sar_Fcrmvi_Identi { get; set; }
        public int Sar_Fcrmvi_Nroitm { get; set; }
        public decimal? Sar_Fcrmvi_Cantid { get; set; }
        public decimal? Sar_Fcrmvi_Precio { get; set; }
        public string Sar_Fcrmvi_Empapl { get; set; }
        public string Sar_Fcrmvi_Modapl { get; set; }
        public string Sar_Fcrmvi_Codapl { get; set; }
        public int? Sar_Fcrmvi_Nroapl { get; set; }
        public int? Sar_Fcrmvi_Itmapl { get; set; }
        public string Sar_Fcrmvi_Tippro { get; set; }
        public string Sar_Fcrmvi_Artcod { get; set; }
        public decimal? Sar_Fcrmvi_Pctbf1 { get; set; }
        public decimal? Sar_Fcrmvi_Pctbf2 { get; set; }
        public decimal? Sar_Fcrmvi_Pctbf3 { get; set; }
        public string Sar_Fcrmvi_Tipcpt { get; set; }
        public string Sar_Fcrmvi_Codcpt { get; set; }
        public string Usr_Fcrmvi_Origen { get; set; }
        public string Usr_Fcrmvi_Deposi { get; set; }
        public string Usr_Fcrmvi_Sector { get; set; }
        public string Usr_Fcrmvi_Selsla { get; set; }
        public decimal? Usr_Fcrmvi_Bonice { get; set; }
        public decimal? Usr_Fcrmvi_Coecar { get; set; }
        public decimal? Usr_Fcrmvi_Prevtx { get; set; }

        public DateTime? Sar_Fc_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Sar_Fc_Fecmod { get; set; } = DateTime.Now;
        public string Sar_Fc_Userid { get; set; } = "API";
        public string Sar_Fc_Ultopr { get; set; } = "A";
        public string Sar_Fc_Debaja { get; set; } = "N";
        public string Sar_Fc_Oalias { get; set; } = "SAR_FCRMVI";

        public virtual Sar_Fcrmvh Sar_Fcrmvh { get; set; }
    }
}
