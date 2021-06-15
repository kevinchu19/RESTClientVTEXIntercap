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
    public class PricesService : ServiceBase<PricesDTO>, IServiceVTEX
    {
        public PricesClient<PricesDTO> _pricesClient { get; }

        public PricesService(PricesClient<PricesDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        {
            _pricesClient = client;
        }

        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation;

            var items = await _repository.ProductsSKU.GetPricesForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE);

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                succesOperation = await _pricesClient.PutPricesAsync(item, item.Id, cancellationToken);
                if (succesOperation)
                {

                    Stmpdh_Real PricesTransfered = await _repository.ProductsSKUReal.Get(cancellationToken, new object[] { item.Stmpdh_Tippro, item.Stmpdh_Artcod });
                    PricesTransfered.Usr_Vtex_Pretra= "S";

                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
