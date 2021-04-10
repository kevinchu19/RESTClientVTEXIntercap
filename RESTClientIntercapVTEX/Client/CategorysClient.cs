using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RESTClientIntercapVTEX.Client
{
    public class CategorysClient<CategoryDTO> : ClientBase<CategoryDTO>
    {
        public CategorysClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger) :
            base(httpClient, configuration, path, logger)
        {

        }
    }
}
