using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Dspeml
    {
        public Usr_Dspeml()
        {
            Contacts = new HashSet<Usr_Dscont>();
            ShippingData = new HashSet<Usr_Dsship>();
            Payments = new HashSet<Usr_Dspaym>();
        }

        public Usr_Dspeml(string Id, decimal? Amount, decimal? Shicos , decimal? Paprov ,DateTime? Fchmov , 
                          string Nrocta , string Prcint , string Prceti , decimal? Cenvin ,
                                    List<Usr_Dscont> _contacts,
                                    List <Usr_Dspaym> _payments,
                                    List <Usr_Dsship> _shippingData)
        {
            Usr_Dspeml_Id = Id;
            Usr_Dspeml_Amount = Amount;
            Usr_Dspeml_Shicos = Shicos;
            Usr_Dspeml_Paprov = Paprov;
            Usr_Dspeml_Fchmov = Fchmov;
            Usr_Dspeml_Nrocta = Nrocta;
            Usr_Dspeml_Prcint = Prcint;
            Usr_Dspeml_Prceti = Prceti;
            Usr_Dspeml_Cenvin = Cenvin;
            Contacts = _contacts;
            Payments = _payments;
            ShippingData = _shippingData;
        }
        public string Usr_Dspeml_Id { get; set; }
        public decimal? Usr_Dspeml_Amount { get; set; }
        public decimal? Usr_Dspeml_Shicos { get; set; }
        public decimal? Usr_Dspeml_Paprov { get; set; }
        public string Usr_Dspeml_Paysta { get; set; }
        public string Usr_Dspeml_Delsta { get; set; }
        public string Usr_Dspeml_Payffs { get; set; }
        public string Usr_Dspeml_Delffs { get; set; }
        public string Usr_Dspeml_Delmet { get; set; }
        public string Usr_Dspeml_Payter { get; set; }
        public string Usr_Dspeml_Curren { get; set; }
        public DateTime? Usr_Dspeml_Fchmov { get; set; }
        public string Usr_Dspeml_Pdtusr { get; set; }
        public short? Usr_Dspeml_Channe { get; set; }
        public string Usr_Dspeml_Isopen { get; set; }
        public string Usr_Dspeml_Iscanc { get; set; }
        public string Usr_Dspeml_Wareho { get; set; }
        public string Usr_Dspeml_Nrocta { get; set; }
        public string Usr_Dspeml_Prcint { get; set; }
        public string Usr_Dspeml_Modfor { get; set; }
        public string Usr_Dspeml_Codfor { get; set; }
        public int? Usr_Dspeml_Nrofor { get; set; }
        public string Usr_Dspeml_Prceti { get; set; }
        public string Usr_Dspeml_Origen { get; set; }
        public decimal? Usr_Dspeml_Cenvin { get; set; }
        public DateTime? Usr_Ds_Fecalt { get; set; } = DateTime.Now;
        public DateTime? Usr_Ds_Fecmod { get; set; } = DateTime.Now;
        public string Usr_Ds_Userid { get; set; } = "API";
        public string Usr_Ds_Ultopr { get; set; } = "A";
        public string Usr_Ds_Debaja { get; set; } = "N";
        public string Usr_Ds_Oalias { get; set; } = "USR_DSPEML";

        public virtual ICollection<Usr_Dscont> Contacts { get; set; }
        public virtual ICollection<Usr_Dspaym> Payments { get; set; }
        public virtual ICollection<Usr_Dsship> ShippingData { get; set; }
    }
}
