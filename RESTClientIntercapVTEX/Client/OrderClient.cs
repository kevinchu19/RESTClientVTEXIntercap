using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Client
{
    public class OrderClient<OrderDTO> :ClientBase<OrderDTO>
    {

        public OrderClient(HttpClient httpClient, IConfigurationRoot configuration, string path, Serilog.ILogger logger) :base(httpClient, configuration,path, logger)
        {}

        public async Task<OrderDTO> DequeueOrderAsync(CancellationToken cancellationToken, string id)
        {
            string path = $"{_path.Replace("$OrderId", id)}";
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Add("X-VTEX-API-AppKey", _appKey);
            request.Headers.Add("X-VTEX-API-AppToken", _appToken);

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) throw new Exception($"Unable to execute GET in the path `{path}`, the status code was `{response.StatusCode}`");

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<OrderDTO>(contentString, jsonSerializerOptions);
        }


        public override Task<VTEXNewIDResponse> PostWithNewIDAsync(OrderDTO data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    
}
