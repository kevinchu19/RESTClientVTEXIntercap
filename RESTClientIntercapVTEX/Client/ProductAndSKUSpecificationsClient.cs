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
    public class ProductAndSKUSpecificationsClient<TResource> : ClientBase<TResource>
    {
        public ProductAndSKUSpecificationsClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger) :
            base(httpClient, configuration, path, logger)
        {

        }

        public async Task<VTEXNewIDResponse> PostSpecificationWithNewIDAsync(TResource data, int Id, CancellationToken cancellationToken)
        {
            var contentString = JsonSerializer.Serialize(data);

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_path}/{Id}/specification")
            {
                Content = new StringContent(contentString, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("X-VTEX-API-AppKey", _appKey);
            request.Headers.Add("X-VTEX-API-AppToken", _appToken);
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
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
                ProductSpecificationDTO responseContent = await JsonSerializer.DeserializeAsync<ProductSpecificationDTO>(await response.Content.ReadAsStreamAsync());
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

        public async Task<bool> DeleteSpecificationAsync(TResource data, int resourceId, int id, CancellationToken cancellationToken)
        {
            string resource = typeof(TResource) == typeof(ProductSpecificationDTO) ? "product" : "stockkeepingunit";

            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_path}/{resourceId}/{resource}/specification/{id}")
            { };
            request.Headers.Add("X-VTEX-API-AppKey", _appKey);
            request.Headers.Add("X-VTEX-API-AppToken", _appToken);
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await JsonSerializer.DeserializeAsync<VTEXErrorResponse>(await response.Content.ReadAsStreamAsync());
                    _logger.Error($"No se puede borrar el recurso {id} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}` y el mensaje de VTEX:`{content.Message}`");
                }
                catch
                {
                    _logger.Error($"No se puede borrar el recurso {id} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}`");
                }
            }
            else
            {
                _logger.Information($"Recurso {id} actualizado en la ruta {_path} exitosamente ");
            }

            return response.IsSuccessStatusCode;


        }



        public override Task<VTEXNewIDResponse> PostWithNewIDAsync(TResource data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
