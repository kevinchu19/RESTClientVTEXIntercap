using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Keywords { get; set; } = "";
        public string SiteTitle { get; set; }
        public bool Active { get; set; }
        public bool MenuHome { get; set; }
        public string AdWordsRemarketingCode { get; set; } = null;
        public string LomadeeCampaignCode { get; set; } = null;
        public int Score { get; set; } 
        public string LinkId { get; set; }

        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        [JsonIgnore]
        public string Usr_St_Oalias { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }
    }
}
