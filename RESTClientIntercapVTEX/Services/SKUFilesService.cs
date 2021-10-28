using AutoMapper;
using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using RESTClientIntercapVTEX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Services
{
    public class SKUFilesService : ServiceBase<SKUFileDTO>, IServiceVTEX
    {
        private SKUFilesClient<SKUFileDTO> _SKUFilesClient { get; }
        public IConfigurationRoot Configuration { get; }

        public SKUFilesService(SKUFilesClient<SKUFileDTO> client,
                                IUnitOfWorkProduccion repository,
                                IMapper mapper,
                                IConfigurationRoot configuration) :
            base(client, repository, mapper)
        {
            _SKUFilesClient = client;
            Configuration = configuration;
        }

        


        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = true;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            var itemsSku = await _repository.ProductsSKUReal.GetSkuForFiles(cancellationToken, MAX_ELEMENTS_IN_QUEUE);
            //var items = _mapper.Map<IEnumerable<Usr_Stimpr>, IEnumerable<SKUFileDTO>>(await _repository.SKUFiles.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

            if (!itemsSku.Any()) return false;

            foreach (var itemSku in itemsSku)
            {
                succesOperation = true;
                await _SKUFilesClient.DeleteAllSkuAsync(itemSku.Usr_Stmpdh_IdSKUvtex, cancellationToken);
                var itemsFiles = _mapper.Map<IEnumerable<Usr_Stimpr>, IEnumerable<SKUFileDTO>>(await _repository.SKUFiles.GetForVTEX(cancellationToken, itemSku.Usr_Stmpdh_IdSKUvtex));
                
                foreach (var item in itemsFiles)
                {
                    item.Url= $"{Configuration["VTEX:ImagesBasePath"]}/{item.Url}.jpg";
                   
                    succesOperationWithNewID = await _SKUFilesClient.PostFileWithNewIDAsync(item,item.SKUId, cancellationToken);
                   
                    if (!succesOperationWithNewID.Success)
                    {
                        succesOperation = false;
                    }   
                }

                if (succesOperation)
                {
                    Stmpdh_Real SkuReal = await _repository.ProductsSKUReal
                                                                         .Get(cancellationToken, new object[] { itemSku.Stmpdh_Tippro.Trim(),
                                                                                                                itemSku.Stmpdh_Artcod.Trim()});
                    if (succesOperationWithNewID.Success)
                    {
                        SkuReal.Usr_Vtex_Imgtra = "S";
                    }

                    await _repository.Complete();
                }

            }
            return itemsSku.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }

}
