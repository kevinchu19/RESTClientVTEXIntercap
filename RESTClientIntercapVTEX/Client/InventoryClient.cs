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
    public class InventoryClient<TResource> : ClientBase<TResource>
    {
        public InventoryClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger) :
            base(httpClient, configuration, path, logger)
        {

        }

        public override Task<VTEXNewIDResponse> PostWithNewIDAsync(TResource data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutInventoryAsync(TResource data, int Id, string wareHouseId,  CancellationToken cancellationToken)
        {
            var contentString = JsonSerializer.Serialize(data);
            string path = $"{_path.Replace("$SkuId", Id.ToString()).Replace("$WarehouseId", wareHouseId)}";
            var request = new HttpRequestMessage(HttpMethod.Put, path)
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
                //_logger.Error($"No se pudo dar de alta el recurso {contentString} en la ruta `{path}`, por error en la conexion`");
            }
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await JsonSerializer.DeserializeAsync<VTEXErrorResponse>(await response.Content.ReadAsStreamAsync());
                    _logger.Error($"No se pudo actualizar el recurso {contentString} en la ruta `{path}`, el statuscode fue `{response.StatusCode}` y el mensaje de VTEX:`{content.Message}`");
                }
                catch
                {
                    _logger.Error($"No se pudo actualizar el recurso {contentString} en la ruta `{path}`, el statuscode fue `{response.StatusCode}`");
                }
            }
            else
            {
                
                _logger.Information($"Recurso {contentString} actualizado en la ruta {path} exitosamente.");
            }

            return response.IsSuccessStatusCode;

        }

    }
}
