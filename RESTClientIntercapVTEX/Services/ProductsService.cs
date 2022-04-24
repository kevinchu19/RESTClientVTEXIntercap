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
                                IUnitOfWorkProduccion repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        { }



        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            

            var productsFather = _mapper.Map<IEnumerable<Usr_Stmpph>, IEnumerable<ProductDTO>>(await _repository.ProductsFather.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            var productsSKUA = await _repository.ProductsSKU.GetProductForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE);
            var productsSKU = _mapper.Map<IEnumerable<Stmpdh>, IEnumerable<ProductDTO>>(await _repository.ProductsSKU.GetProductForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

            IEnumerable<ProductDTO> items = productsFather.Concat(productsSKU).OrderBy(c => c.Sfl_LoginDateTime).Take(MAX_ELEMENTS_IN_QUEUE);
            if (!items.Any()) return false;

            foreach (var item in items)
            {
                VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();
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

                            //21/10/2021: Se deja de utilizar tabla de log para enviar productos
                            //Stmpdh productSKUTransfered = await _repository.ProductsSKU.Get(cancellationToken, new object[] {item.RowId});
                            //Stmpdh_Real productSKUReal = await _repository.ProductsSKUReal
                            //                                                .Get(cancellationToken, new object[] { item.Stmpdh_Tippro.Trim(), 
                            //                                                                                       item.Stmpdh_Artcod.Trim() });


                            //productSKUReal.Usr_Vtex_Transf = "S";

                            //if (succesOperationWithNewID.Success)
                            //{
                            //    productSKUReal.Usr_Stmpdh_Idvtex = succesOperationWithNewID.NewId;

                            //}

                            await _repository.ProductsSKUReal.MarcarProductoTransferido(cancellationToken, item.Stmpdh_Tippro.Trim(), item.Stmpdh_Artcod.Trim(), succesOperationWithNewID.NewId);
                            break;
                        case "USR_STMPPH":
                            Usr_Stmpph productFatherTransfered = await _repository.ProductsFather.Get(cancellationToken, new object[] { item.RowId });
                            Usr_Stmpph_Real productFatherReal = await _repository.ProductsFatherReal
                                                                            .Get(cancellationToken, new object[] { productFatherTransfered.Usr_Stmpph_Indcod.Trim() });

                            
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
                            Stmpdh_Real productSKU = await _repository.ProductsSKUReal.Get(cancellationToken, new object[] {item.Stmpdh_Tippro.Trim(), item.Stmpdh_Artcod.Trim() });
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
