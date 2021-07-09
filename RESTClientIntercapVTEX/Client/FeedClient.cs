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
    public class FeedClient<FeedDTO> :ClientBase<FeedDTO>
    {

        public FeedClient(HttpClient httpClient, IConfigurationRoot configuration, string path, Serilog.ILogger logger) :base(httpClient, configuration,path, logger)
        {}

        public async Task<IEnumerable<FeedDTO>> DequeueAsync(CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _path);
            request.Headers.Add("X-VTEX-API-AppKey", _appKey);
            request.Headers.Add("X-VTEX-API-AppToken", _appToken);

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) throw new Exception($"Unable to execute GET in the path `{_path}`, the status code was `{response.StatusCode}`");

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<IEnumerable<FeedDTO>>(contentString, jsonSerializerOptions);
        }

        public async Task CommitAsync(IEnumerable<string> handles, CancellationToken cancellationToken)
        {
            var path = "api/orders/feed";
            var contentString = JsonSerializer.Serialize(new { handles });
            var request = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(contentString)
            };
            request.Headers.Add("X-VTEX-API-AppKey", _appKey);
            request.Headers.Add("X-VTEX-API-AppToken", _appToken);

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) throw new Exception($"Unable to execute POST in the path `{path}`, the status code was `{response.StatusCode}`");
        }

        public override Task<VTEXNewIDResponse> PostWithNewIDAsync(FeedDTO data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    
}
