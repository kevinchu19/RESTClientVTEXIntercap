using RESTClientIntercapVTEX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Models
{
    class BackgroundServicesModel
    {
        public string Description { get; set; }
        public IServiceVTEX Service { get; set; }
    }
}
