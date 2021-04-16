using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Client
{
    public class CategorysClient<CategoryDTO> : ClientBase<CategoryDTO>
    {
        public CategorysClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger) :
            base(httpClient, configuration, path, logger)
        {

        }

        public override Task<VTEXNewIDResponse> PostWithNewIDAsync(CategoryDTO data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
