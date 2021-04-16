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
                        succesOperation = await _client.PostAsync(item, cancellationToken);
                        break;
                    case "UPDATE":
                        succesOperation = await _client.PutAsync(item, item.RefId.ToString(), cancellationToken);
                        break;
                    default:
                        break;
                }

                if (succesOperation)
                {

                    switch (item.Stmpdh_Oalias)
                    {
                        case "STMPDH":
                            Stmpdh productSKU = await _repository.ProductsSKU.Get(cancellationToken, new object[] {item.RowId});
                            productSKU.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STMPPH":
                            Usr_Stmpph productFather = await _repository.ProductsFather.Get(cancellationToken, new object[] {item.RowId});
                            productFather.Usr_Vtex_Transf = "S";
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
