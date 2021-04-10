﻿using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RESTClientIntercapVTEX.Client
{
    public class SpecificationsClient<SpecificationDTO> : ClientBase<SpecificationDTO>
    {
        public SpecificationsClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger):
            base(httpClient, configuration, path, logger)
        {

        }
    }
}
