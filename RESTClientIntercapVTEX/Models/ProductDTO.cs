
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RESTClientIntercapVTEX.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string LinkId { get; set; }
        public string RefId { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public string DescriptionShort { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string KeyWords { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string TaxCode { get; set; } = "";
        public string MetaTagDescription { get; set; }
        public int SupplierId { get; set; } = 1;
        public bool ShowWithoutStock { get; set; } = true;
        public string AdWordsRemarketingCode { get; set; }
        public string LomadeeCampaignCode { get; set; }
        public int Score { get; set; }
        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }
        [JsonIgnore]
        public string Stmpdh_Oalias { get; set; }
        [JsonIgnore]
        public string Stmpdh_Tippro { get; set; }

        [JsonIgnore]
        public string Stmpdh_Artcod { get; set; }
    }
}
