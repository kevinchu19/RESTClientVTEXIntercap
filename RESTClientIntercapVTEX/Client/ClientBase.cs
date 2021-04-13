
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////// TODO: Marcar datos enviados como transferidos /////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////

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
    public abstract class ClientBase<TResource>
    {
        
        private readonly HttpClient _httpClient;
        private readonly string _appKey;
        private readonly string _appToken;
        private readonly string _path;
        public ILogger _logger { get; }
        public ClientBase(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger)
        {
            _httpClient = httpClient;
            _path = path;
            _httpClient.BaseAddress = new Uri(configuration["VTEX:BaseAddress"]);
            _appKey = configuration["VTEX:AppKey"];
            _appToken = configuration["VTEX:AppToken"];
            _logger = logger;
        }

        

        public async Task<IEnumerable<TResource>> DequeueAsync(CancellationToken cancellationToken)
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
            return JsonSerializer.Deserialize<IEnumerable<TResource>>(contentString, jsonSerializerOptions);
        }

        public async Task<bool> PutAsync(TResource data,string id, CancellationToken cancellationToken)
        {
            {
                var contentString = JsonSerializer.Serialize(data);
                var request = new HttpRequestMessage(HttpMethod.Put, $"{_path}/{id}")
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
                        _logger.Error($"No se puede actualizar el recurso {contentString} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}` y el mensaje de VTEX:`{content.Message}`");
                    }
                    catch 
                    {
                        _logger.Error($"No se puede actualizar el recurso {contentString} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}`");
                    }
                }
                else
                {
                    _logger.Information($"Recurso {contentString} actualizado en la ruta {_path} exitosamente ");
                }

                return response.IsSuccessStatusCode;

            }
        }


        public async Task<bool> PostAsync (TResource data, CancellationToken cancellationToken)
        {
            var contentString = JsonSerializer.Serialize(data);
            var request = new HttpRequestMessage(HttpMethod.Post, _path)
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
                catch(Exception ex)
                {
                    _logger.Error($"No se pudo dar de alta el recurso {contentString} en la ruta `{_path}`, el statuscode fue `{response.StatusCode}`");
                }
            }
            else
            {
                _logger.Information($"Recurso {contentString} dado de alta en la ruta {_path} exitosamente ");
            }
            
            return response.IsSuccessStatusCode;
        }

    }
}
