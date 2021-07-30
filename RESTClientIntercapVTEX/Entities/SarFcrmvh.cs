using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Sar_Fcrmvh
    {
        public Sar_Fcrmvh() {
            Sar_Fcrmvis = new HashSet<Sar_Fcrmvi>();
        }
        public Sar_Fcrmvh(string Identi, string Status, string Nrocta, DateTime? Fchmov,
                          string Circom, string Cirapl, string Codemp, string Modfor,
                          string Codfor, List<Sar_Fcrmvi> Items)
        {

            this.Sar_Fcrmvh_Identi = Identi;
            this.Sar_Fcrmvh_Status = Status;
            this.Sar_Fcrmvh_Nrocta =  Nrocta;
            this.Sar_Fcrmvh_Fchmov = Fchmov;
            this.Sar_Fcrmvh_Circom = Circom;
            this.Sar_Fcrmvh_Cirapl = Cirapl;
            this.Sar_Fcrmvh_Codemp = Codemp;
            this.Sar_Fcrmvh_Modfor = Modfor;
            this.Sar_Fcrmvh_Codfor = Codfor;
            this.Sar_Fcrmvis = Items;
        }
        public string Sar_Fcrmvh_Identi { get; set; }
        public string Sar_Fcrmvh_Status { get; set; }
        public string Sar_Fcrmvh_Nrocta { get; set; }
        public DateTime? Sar_Fcrmvh_Fchmov { get; set; }
        public string Sar_Fcrmvh_Circom { get; set; }
        public string Sar_Fcrmvh_Cirapl { get; set; }
        public string Sar_Fcrmvh_Codemp { get; set; }
        public string Sar_Fcrmvh_Modfor { get; set; }
        public string Sar_Fcrmvh_Codfor { get; set; }
        public int? Sar_Fcrmvh_Nrofor { get; set; }
        public string Sar_Fcrmvh_Jurisd { get; set; }
        public string Sar_Fcrmvh_Deposi { get; set; }
        public string Sar_Fcrmvh_Sector { get; set; }
        public string Sar_Fcrmvh_Empfst { get; set; }
        public string Sar_Fcrmvh_Modfst { get; set; }
        public string Sar_Fcrmvh_Codfst { get; set; }
        public int? Sar_Fcrmvh_Nrofst { get; set; }
        public string Sar_Fcrmvh_Empfvt { get; set; }
        public string Sar_Fcrmvh_Modfvt { get; set; }
        public string Sar_Fcrmvh_Codfvt { get; set; }
        public int? Sar_Fcrmvh_Nrofvt { get; set; }
        public string Sar_Fcrmvh_Empfcj { get; set; }
        public string Sar_Fcrmvh_Modfcj { get; set; }
        public string Sar_Fcrmvh_Genfac { get; set; }
        public string Sar_Fcrmvh_Codfcj { get; set; }
        public int? Sar_Fcrmvh_Nrofcj { get; set; }
        public string Sar_Fcrmvh_Errmsg { get; set; }
        public string Sar_Fcrmvh_Camion { get; set; }
        public string Sar_Fcrmvh_Tracod { get; set; }
        public string Sar_Fcrmvh_Sucurs { get; set; }
        public string Sar_Fcrmvh_Vnddor { get; set; }
        public string Sar_Fcrmvh_Textos { get; set; }
        public string Sar_Fcrmvh_Ejeaut { get; set; } = "N";
        public string Sar_Fcrmvh_Codjob { get; set; } = "USR_FC";
        public string Sar_Fcrmvh_Cofdeu { get; set; }
        public string Sar_Fcrmvh_Coffac { get; set; }
        public string Sar_Fcrmvh_Coflis { get; set; }
        public decimal? Sar_Fcrmvh_Cambio { get; set; }
        public string Sar_Fcrmvh_Nombre { get; set; }
        public string Sar_Fcrmvh_Direcc { get; set; }
        public string Sar_Fcrmvh_Codpai { get; set; }
        public string Sar_Fcrmvh_Codpos { get; set; }
        public string Sar_Fcrmvh_Cntpdc { get; set; }
        public string Sar_Fcrmvh_Nrodoc { get; set; }
        public string Sar_Fcrmvh_Coniva { get; set; }
        public string Sar_Fcrmvh_Jurctd { get; set; }
        public string Sar_Fcrmvh_Tipdo1 { get; set; }
        public string Sar_Fcrmvh_Nrodo1 { get; set; }
        public string Sar_Fcrmvh_Tipdo2 { get; set; }
        public string Sar_Fcrmvh_Nrodo2 { get; set; }
        public string Sar_Fcrmvh_Telefn { get; set; }
        public string Sar_Fcrmvh_Direml { get; set; }
        public string Sar_Fcrmvh_Tranum { get; set; }
        public string Sar_Fcrmvh_Traurl { get; set; }
        public string Sar_Fcrmvh_Codlis { get; set; }
        public DateTime? Sar_Fc_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Sar_Fc_Fecmod { get; set; } = DateTime.Now;
        public string Sar_Fc_Userid { get; set; } = "API";
        public string Sar_Fc_Ultopr { get; set; } = "A";
        public string Sar_Fc_Debaja { get; set; } = "N";
        public string Sar_Fc_Oalias { get; set; } = "SAR_FCRMVH";

        public virtual ICollection<Sar_Fcrmvi> Sar_Fcrmvis { get; set; }
    }
}
