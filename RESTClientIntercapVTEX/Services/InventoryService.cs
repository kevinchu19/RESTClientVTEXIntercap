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
    public class InventoryService : ServiceBase<InventoryDTO>, IServiceVTEX
    {
        public InventoryClient<InventoryDTO> _inventoryClient { get; }

        public InventoryService(InventoryClient<InventoryDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        {
            _inventoryClient = client;
        }




        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation;
            string previousTippro = "";
            string previousArtcod = "";
            var items = await _repository.ProductsSKU.GetInventoryForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE);

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                
                succesOperation = await _inventoryClient.PutInventoryAsync(item, item.Id, item.WarehouseId,cancellationToken);
                if (succesOperation)
                {

                    if ((item.Stmpdh_Tippro != previousTippro || item.Stmpdh_Artcod != previousArtcod) && previousTippro != "")
                    {
                        Stmpdh_Real inventoryTransfered = await _repository.ProductsSKUReal.Get(cancellationToken, new object[] { previousTippro.Trim(), previousArtcod.Trim() });
                        inventoryTransfered.Usr_Vtex_Stktra = "S";

                        await _repository.Complete();
                    }
                    
                }
                previousTippro = item.Stmpdh_Tippro;
                previousArtcod = item.Stmpdh_Artcod;
            }
            
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
