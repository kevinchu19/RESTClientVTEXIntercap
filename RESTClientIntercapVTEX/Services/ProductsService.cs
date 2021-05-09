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
    public class ProductsService : ServiceBase<ProductDTO>, IServiceVTEX
    {

        public ProductsService(ProductsClient<ProductDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        { }



        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            var productsFather = _mapper.Map<IEnumerable<Usr_Stmpph>, IEnumerable<ProductDTO>>(await _repository.ProductsFather.GetForVTEX(cancellationToken));
            var productsSKU = _mapper.Map<IEnumerable<Stmpdh>, IEnumerable<ProductDTO>>(await _repository.ProductsSKU.GetProductForVTEX(cancellationToken));

            IEnumerable<ProductDTO> items = productsFather.Concat(productsSKU).OrderBy(c => c.Sfl_LoginDateTime);
            if (!items.Any()) return false;

            foreach (var item in items)
            {
                // Put in your internal queue to process async
                // It is not recommend to process direct here, if your systems start to get slow the item will be visible in the queue and you will process more the one time
                switch (item.Sfl_TableOperation)
                {
                    case "INSERT":
                        succesOperationWithNewID = await _client.PostWithNewIDAsync(item, cancellationToken);
                        break;
                    case "UPDATE":
                        if (item.Id == 0) //Quiere decir que no se dio de alta en vtex aun
                        {
                            succesOperationWithNewID = await _client.PostWithNewIDAsync(item, cancellationToken);
                        }
                        else
                        {
                            succesOperation = await _client.PutAsync(item, item.Id.ToString(), cancellationToken);
                        }
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {

                    switch (item.Stmpdh_Oalias)
                    {
                        case "STMPDH":
                            Stmpdh productSKUTransfered = await _repository.ProductsSKU.Get(cancellationToken, new object[] {item.RowId});
                            Stmpdh_Real productSKUReal = await _repository.ProductsSKUReal
                                                                            .Get(cancellationToken, new object[] { productSKUTransfered.Stmpdh_Tippro, 
                                                                                                                   productSKUTransfered.Stmpdh_Artcod });


                            productSKUTransfered.Usr_Vtex_Transf = "S";
                            if (succesOperationWithNewID.Success)
                            {
                                productSKUReal.Usr_Stmpdh_Idvtex = succesOperationWithNewID.NewId;
                                productSKUTransfered.Usr_Stmpdh_Idvtex = succesOperationWithNewID.NewId;
                            }
                            break;
                        case "USR_STMPPH":
                            Usr_Stmpph productFatherTransfered = await _repository.ProductsFather.Get(cancellationToken, new object[] { item.RowId });
                            Usr_Stmpph_Real productFatherReal = await _repository.ProductsFatherReal
                                                                            .Get(cancellationToken, new object[] { productFatherTransfered.Usr_Stmpph_Indcod});

                            
                            productFatherTransfered.Usr_Vtex_Transf = "S";
                            if (succesOperationWithNewID.Success)
                            {
                                productFatherReal.Usr_Stmpph_Idvtex = succesOperationWithNewID.NewId;
                            }
                            break;
                      
                        default:
                            break;
                    }
                    await _repository.Complete();
                }
                else
                {
                    switch (item.Stmpdh_Oalias)
                    {
                        case "STMPDH":
                            Stmpdh productSKU = await _repository.ProductsSKU.Get(cancellationToken, new object[] {item.RowId});
                            productSKU.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STMPPH":
                            Usr_Stmpph productFather = await _repository.ProductsFather.Get(cancellationToken, new object[] {item.RowId});
                            productFather.Usr_Vtex_Transf = "E";
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
