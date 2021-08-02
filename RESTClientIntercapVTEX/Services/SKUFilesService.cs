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
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();
            
            var items = _mapper.Map<IEnumerable<Usr_Stimpr>, IEnumerable<SKUFileDTO>>(await _repository.SKUFiles.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                item.Url = $"{Configuration["VTEX:ImagesBasePath"]}/{item.Url}.jpg";
                switch (item.Sfl_TableOperation)
                {
                    case "INSERT":
                    case "UPDATE":
                        succesOperationWithNewID = await _SKUFilesClient.PostFileWithNewIDAsync(item,item.SKUId, cancellationToken);
                        break;
                    case "DELETE":
                        if (item.Id != 0) 
                        {
                            succesOperation = await _SKUFilesClient.DeleteFileAsync(item.SKUId, item.Id, cancellationToken);
                        }
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {

                    Usr_Stimpr SKUFileTransfered = await _repository.SKUFiles.Get(cancellationToken, new object[] { item.RowId });
                    Usr_Stimpr_Real SKUFileReal = await _repository.SKUFilesReal
                                                                    .Get(cancellationToken, new object[] { SKUFileTransfered.Usr_Stimpr_Tippro.Trim(),
                                                                                                            SKUFileTransfered.Usr_Stimpr_Artcod.Trim(),
                                                                                                            SKUFileTransfered.Usr_Stimpr_Orden});


                    SKUFileTransfered.Usr_Vtex_Transf = "S";
                    if (succesOperationWithNewID.Success)
                    {
                        SKUFileReal.Usr_Stimpr_Idvtex = succesOperationWithNewID.NewId;
                        SKUFileTransfered.Usr_Stimpr_Idvtex = succesOperationWithNewID.NewId;
                    }
                         
                    await _repository.Complete();
                }
                else
                {
                    
                    Usr_Stimpr SKUFileTransfered = await _repository.SKUFiles.Get(cancellationToken, new object[] { item.RowId });
                    SKUFileTransfered.Usr_Vtex_Transf = "E";
                    
                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }

}
