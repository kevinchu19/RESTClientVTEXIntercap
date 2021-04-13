using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RESTClientIntercapVTEX.Client
{
    public class SpecificationGroupClient<SpecificationGroupDTO> : ClientBase<SpecificationGroupDTO>
    {
        public SpecificationGroupClient(HttpClient httpClient, IConfigurationRoot configuration, string path, Serilog.ILogger logger) :
            base(httpClient, configuration, path, logger)
        {

        }


    }
}
