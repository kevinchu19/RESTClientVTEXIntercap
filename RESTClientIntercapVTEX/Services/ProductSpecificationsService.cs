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
    public class ProductSpecificationsService : ServiceBase<ProductSpecificationDTO>, IServiceVTEX
    {
        private ProductAndSKUSpecificationsClient<ProductSpecificationDTO> _specificationsClient { get; }

        public ProductSpecificationsService(ProductAndSKUSpecificationsClient<ProductSpecificationDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        {
            _specificationsClient = client;
        }

        


        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();
            
            var productSpecifications = _mapper.Map<IEnumerable<Usr_Pratri>, IEnumerable<ProductSpecificationDTO>>(await _repository.ProductsAndSKUSpecifications.GetProductSpecificationForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            var productFatherSpecifications = _mapper.Map<IEnumerable<Usr_Stmppa>, IEnumerable<ProductSpecificationDTO>>(await _repository.ProductsFatherSpecifications.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            
            IEnumerable<ProductSpecificationDTO> items = productSpecifications.Concat(productFatherSpecifications).OrderBy(c => c.Sfl_LoginDateTime).Take(MAX_ELEMENTS_IN_QUEUE);

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                // Put in your internal queue to process async
                // It is not recommend to process direct here, if your systems start to get slow the item will be visible in the queue and you will process more the one time
                switch (item.Sfl_TableOperation)
                {
                    case "INSERT":case "UPDATE":
                        succesOperation = await _specificationsClient.PostProductSpecificationAsync(new List<ProductSpecificationDTO> { item},item.ProductId, cancellationToken);
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
                            productSpecificationTransfered.Usr_Vtex_Transf = "S";
                            
                            break;
                        case "USR_STMPPA":
                            Usr_Stmppa productFatherSpecificationTransfered = await _repository.ProductsFatherSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            productFatherSpecificationTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_PRATRM":
                            Usr_Pratrm productMotoSpecificationTransfered = await _repository.ProductsFatherMotoSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            productMotoSpecificationTransfered.Usr_Vtex_Transf = "S";
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

                        case "USR_PRATRM":
                            Usr_Pratrm productMotoSpecificationTransfered = await _repository.ProductsFatherMotoSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            productMotoSpecificationTransfered.Usr_Vtex_Transf = "E";
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
