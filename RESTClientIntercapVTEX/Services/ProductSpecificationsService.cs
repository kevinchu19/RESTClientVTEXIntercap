﻿using AutoMapper;
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
    public class ProductSpecificationsService : ServiceBase<ProductSpecificationDTO>, IServiceVTEX
    {
        private ProductAndSKUSpecificationsClient<ProductSpecificationDTO> _specificationsClient { get; }

        public ProductSpecificationsService(ProductAndSKUSpecificationsClient<ProductSpecificationDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper,
                                ProductAndSKUSpecificationsClient<ProductSpecificationDTO> specificationsClient) :
            base(client, repository, mapper)
        {
            _specificationsClient = specificationsClient;
        }

        


        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();
            
            var productSpecifications = _mapper.Map<IEnumerable<Usr_Pratri>, IEnumerable<ProductSpecificationDTO>>(await _repository.ProductsAndSKUSpecifications.GetProductSpecificationForVTEX(cancellationToken));
            var productFatherSpecifications = _mapper.Map<IEnumerable<Usr_Stmppa>, IEnumerable<ProductSpecificationDTO>>(await _repository.ProductsFatherSpecifications.GetForVTEX(cancellationToken));
            
            IEnumerable<ProductSpecificationDTO> items = productSpecifications.Concat(productFatherSpecifications).OrderBy(c => c.Sfl_LoginDateTime);

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                // Put in your internal queue to process async
                // It is not recommend to process direct here, if your systems start to get slow the item will be visible in the queue and you will process more the one time
                switch (item.Sfl_TableOperation)
                {
                    case "INSERT":case "UPDATE":
                        succesOperationWithNewID = await _specificationsClient.PostSpecificationWithNewIDAsync(item,item.ProductId, cancellationToken);
                        break;
                    case "DELETE":
                        if (item.Id != 0) 
                        {
                            succesOperation = await _specificationsClient.DeleteSpecificationAsync(item,item.ProductId, item.Id, cancellationToken);
                        }
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {

                    switch (item.Usr_St_Oalias)
                    {
                        case "USR_PRATRI":
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
                            break;
                        case "USR_STMPPA":
                            Usr_Stmppa productFatherSpecificationTransfered = await _repository.ProductsFatherSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            Usr_Stmppa_Real productFatherSpecificationReal = await _repository.ProductsFatherSpecificationsReal
                                                                            .Get(cancellationToken, new object[] { productFatherSpecificationTransfered.Usr_Stmppa_Indcod,
                                                                                                                   productFatherSpecificationTransfered.Usr_Stmppa_Orden});


                            productFatherSpecificationTransfered.Usr_Vtex_Transf = "S";
                            if (succesOperationWithNewID.Success)
                            {
                                productFatherSpecificationReal.Usr_Stmppa_Idvtex = succesOperationWithNewID.NewId;
                            }
                            break;

                        default:
                            break;
                    }
                    await _repository.Complete();
                }
                else
                {
                    switch (item.Usr_St_Oalias)
                    {
                        case "USR_PRATRI":
                            Usr_Pratri productSpecificationTransfered = await _repository.ProductsAndSKUSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            productSpecificationTransfered.Usr_Vtex_Transf = "E";
                            break;

                        case "USR_STMPPA":
                            Usr_Stmppa productFatherSpecificationTransfered = await _repository.ProductsFatherSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            productFatherSpecificationTransfered.Usr_Vtex_Transf = "E";
                            break;
                        default:
                            break;
                    }
                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }

}