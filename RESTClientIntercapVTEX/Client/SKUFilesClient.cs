﻿using Microsoft.Extensions.Configuration;
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
    public class SKUFilesClient<TResource> : ClientBase<TResource>
    {
        public SKUFilesClient(HttpClient httpClient, IConfigurationRoot configuration, string path, ILogger logger) :
            base(httpClient, configuration, path, logger)
        {

        }

        public async Task<VTEXNewIDResponse> PostFileWithNewIDAsync(TResource data, int Id, CancellationToken cancellationToken)
        {
            var contentString = JsonSerializer.Serialize(data);

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_path}/{Id}/file")
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
                SKUFileDTO responseContent = await JsonSerializer.DeserializeAsync<SKUFileDTO>(await response.Content.ReadAsStreamAsync());
                _logger.Information($"Recurso {contentString} dado de alta en la ruta {_path} exitosamente y se le dió el id {responseContent.ArchiveId}");
                return new VTEXNewIDResponse()
                {
                    Success = response.IsSuccessStatusCode,
                    NewId = responseContent.ArchiveId
                };
            }

            return new VTEXNewIDResponse()
            {
                Success = response.IsSuccessStatusCode,
                NewId = 0
            };

        }

        public async Task<bool> DeleteFileAsync( int resourceId, int id, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_path}/{resourceId}/file/{id}")
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