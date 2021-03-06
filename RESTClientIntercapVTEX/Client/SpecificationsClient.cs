using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Client
{
    public class SpecificationsClient<TResource> : ClientBase<TResource>
    {
        public SpecificationsClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger):
            base(httpClient, configuration, path, logger)
        {

        }

        public async override Task<VTEXNewIDResponse> PostWithNewIDAsync(TResource data, CancellationToken cancellationToken)
        {
            var contentString = JsonSerializer.Serialize(data);
            var request = new HttpRequestMessage(HttpMethod.Post, _path)
            {
                Content = new StringContent(contentString, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("X-VTEX-API-AppKey", _appKey);
            request.Headers.Add("X-VTEX-API-AppToken", _appToken);
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                _logger.Error($"No se pudo dar de alta el recurso {contentString} en la ruta `{_path}`, por error en la conexion`");
            }
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await JsonSerializer.DeserializeAsync<VTEXErrorResponse>(await response.Content.ReadAsStreamAsync());
                    _logger.Error($"No se pudo dar de alta el recurso {contentString} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}` y el mensaje de VTEX:`{content.Message}`");
                }
                catch
                {
                    _logger.Error($"No se pudo dar de alta el recurso {contentString} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}`");
                }
            }
            else
            {
                SpecificationDTO responseContent = await JsonSerializer.DeserializeAsync<SpecificationDTO>(await response.Content.ReadAsStreamAsync());
                _logger.Information($"Recurso {contentString} dado de alta en la ruta {_path} exitosamente y se le dió el id {responseContent.Id}");
                return new VTEXNewIDResponse()
                {
                    Success = response.IsSuccessStatusCode,
                    NewId = responseContent.Id
                };
            }

            return new VTEXNewIDResponse()
            {
                Success = response.IsSuccessStatusCode,
                NewId = 0
            };
        }
    }
}
