﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RESTClientIntercapVTEX.Entities
{
    public partial class Usr_Prmoto
    {
        public string Usr_Prmoto_Idmoto { get; set; }
        public string Usr_Prmoto_Marca { get; set; }
        public string Usr_Prmoto_Modelo { get; set; }
        public string Usr_Prmoto_Version { get; set; }
        public string Usr_Prmoto_Cilind { get; set; }
        public string Usr_Prmoto_Tipmot { get; set; }
        public string Usr_Prmoto_Adesde { get; set; }
        public string Usr_Prmoto_Ahasta { get; set; }
        public DateTime? Usr_Pr_Fecalt { get; set; }
        public DateTime? Usr_Pr_Fecmod { get; set; }
        public string Usr_Pr_Userid { get; set; }
        public string Usr_Pr_Ultopr { get; set; }
        public string Usr_Pr_Debaja { get; set; }
        public string Usr_Pr_Oalias { get; set; }
        public string Usr_Vtex_Transf { get; set; }
        public int? Usr_Vtex_Anohastra { get; set; }
        public DateTime Sfl_LoginDateTime { get; set; }
        public string Sfl_TableOperation { get; set; }
        public int RowId { get; set; }
    }
}
