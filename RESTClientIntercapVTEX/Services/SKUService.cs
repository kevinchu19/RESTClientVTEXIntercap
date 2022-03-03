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
    public class SKUService : ServiceBase<SkuDTO>, IServiceVTEX
    {

        public SKUService(SKUClient<SkuDTO> client,
                                IUnitOfWorkProduccion repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        { }



        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            IEnumerable<SkuDTO> items = _mapper.Map<IEnumerable<Stmpdh>, IEnumerable<SkuDTO>>(await _repository.ProductsSKU.GetSKUForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
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
                    if (item.RowId == 0) //Activacion de SKU
                    {
                        //Stmpdh_Real SKUReal = await _repository.ProductsSKUReal
                        //                                            .Get(cancellationToken, new object[] { item.RefId.Substring(0,3) ,
                        //                                                                                       item.RefId.Substring(3,9) });


                        //SKUReal.Usr_Vtex_Isacti = "S";

                        await _repository.ProductsSKUReal.MarcarSKUActivado(cancellationToken, item.Stmpdh_Tippro.Trim(), item.Stmpdh_Artcod.Trim());
                    } 
                    else
                    { 
                        //21/10/2021: Se deja de usar tabla de log para transferir productos
                        //Stmpdh SKUTransfered = await _repository.ProductsSKU.Get(cancellationToken, new object[] { item.RowId });
                        //07/02/2022: Se deja de usar entity framework para actualizar campo

                        //Stmpdh_Real SKUReal = await _repository.ProductsSKUReal
                        //                                                .Get(cancellationToken, new object[] { item.Stmpdh_Tippro.Trim(),
                        //                                                                                    item.Stmpdh_Artcod.Trim() });
                        //SKUReal.Usr_Vtex_Skutra = "S";

                        //if (succesOperationWithNewID.Success)
                        //{
                        //    SKUReal.Usr_Stmpdh_IdSKUvtex = succesOperationWithNewID.NewId;
                        //}

                        await _repository.ProductsSKUReal.MarcarSKUTransferido(cancellationToken, item.Stmpdh_Tippro.Trim(), item.Stmpdh_Artcod.Trim(), succesOperationWithNewID.NewId);

                    }
                    
                    //await _repository.Complete();
                }
                else
                {
                    if (item.RowId != 0)
                    {
                        Stmpdh_Real Sku = await _repository.ProductsSKUReal.Get(cancellationToken, new object[] { item.Stmpdh_Tippro.Trim(), 
                                                                                                                  item.Stmpdh_Artcod.Trim() });
                        Sku.Usr_Vtex_Skutra = "E";
                        await _repository.Complete();
                    }
                    
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
