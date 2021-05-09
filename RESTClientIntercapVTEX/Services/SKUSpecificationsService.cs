using AutoMapper;
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
    public class SKUSpecificationsService : ServiceBase<SKUSpecificationDTO>, IServiceVTEX
    {
        private ProductAndSKUSpecificationsClient<SKUSpecificationDTO> _SKUspecificationsClient { get; }

        public SKUSpecificationsService(ProductAndSKUSpecificationsClient<SKUSpecificationDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper,
                                ProductAndSKUSpecificationsClient<SKUSpecificationDTO> SKUspecificationsClient) :
            base(client, repository, mapper)
        {
            _SKUspecificationsClient = SKUspecificationsClient;
        }

        


        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();
            
            var items = _mapper.Map<IEnumerable<Usr_Pratri>, IEnumerable<SKUSpecificationDTO>>(await _repository.ProductsAndSKUSpecifications.GetSKUSpecificationForVTEX(cancellationToken));

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                // Put in your internal queue to process async
                // It is not recommend to process direct here, if your systems start to get slow the item will be visible in the queue and you will process more the one time
                switch (item.Sfl_TableOperation)
                {
                    case "INSERT": case "UPDATE":
                        succesOperationWithNewID = await _SKUspecificationsClient.PostSpecificationWithNewIDAsync(item,item.SKUId, cancellationToken);
                        break;
                    case "DELETE":
                        if (item.Id != 0) 
                        {
                            succesOperation = await _SKUspecificationsClient.DeleteSpecificationAsync(item,item.SKUId, item.Id, cancellationToken);
                        }
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {

                    Usr_Pratri productSpecificationTransfered = await _repository.ProductsAndSKUSpecifications.Get(cancellationToken, new object[] { item.RowId });
                    Usr_Pratri_Real productSpecificationReal = await _repository.ProductsAndSKUSpecificationsReal
                                                                    .Get(cancellationToken, new object[] { productSpecificationTransfered.Usr_Pratri_Tippro,
                                                                                                            productSpecificationTransfered.Usr_Pratri_Artcod,
                                                                                                            productSpecificationTransfered.Usr_Pratri_Orden});


                    productSpecificationTransfered.Usr_Vtex_Transf = "S";
                    if (succesOperationWithNewID.Success)
                    {
                        productSpecificationReal.Usr_Pratri_Idvtex = succesOperationWithNewID.NewId;
                        productSpecificationTransfered.Usr_Pratri_Idvtex = succesOperationWithNewID.NewId;
                    }
                         
                    await _repository.Complete();
                }
                else
                {
                    
                    Usr_Pratri productSpecificationTransfered = await _repository.ProductsAndSKUSpecifications.Get(cancellationToken, new object[] { item.RowId });
                    productSpecificationTransfered.Usr_Vtex_Transf = "E";
                    
                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }

}
