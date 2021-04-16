using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FatherCategoryId { get; set; } = null;
        public string GlobalCategoryId { get; set; } = null;
        public bool ShowInStoreFront { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public bool ActiveStoreFrontLink { get; set; } = true;
        public bool ShowBrandFilter { get; set; } = true;
        public int Score { get; set; }
        public string StockKeepingUnitSelectionMode { get; set; } = "SPECIFICATION";
        [JsonIgnore]
        public DateTime Sfl_LoginDateTime { get; set; }
        [JsonIgnore]
        public string Sfl_TableOperation  { get; set; }
        [JsonIgnore]
        public string Usr_St_Oalias { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }

    }
}
