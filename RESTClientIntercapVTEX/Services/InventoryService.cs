using AutoMapper;
using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using RESTClientIntercapVTEX.Services.Interfaces;
using Serilog;
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
        public ILogger _logger { get; }

        public InventoryService(InventoryClient<InventoryDTO> client,
                                IUnitOfWorkProduccion repository,
                                IMapper mapper,
                                Serilog.ILogger logger) :
            base(client, repository, mapper)
        {
            _inventoryClient = client;
            _logger = logger;
        }




        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation;

            var itemsSku = await _repository.ProductsSKUReal.GetSkuForInventory(cancellationToken, MAX_ELEMENTS_IN_QUEUE);
      

            if (!itemsSku.Any()) return false;

            foreach (var itemSku in itemsSku)
            {
                var itemsInventory = await _repository.ProductsSKU.GetInventoryForVTEX(cancellationToken, itemSku.Usr_Stmpdh_IdSKUvtex);
                foreach (var item in itemsInventory)
                {
                    succesOperation = await _inventoryClient.PutInventoryAsync(item, item.Id, item.WarehouseId,cancellationToken);
                }

                //15/01/2022: Reemplazo EF porque no actualiza como transferido
                //Stmpdh_Real inventoryTransfered = await _repository.'ProductsSKUReal.Get(cancellationToken, new object[] { itemSku.Stmpdh_Tippro.Trim(), 
                //                                                                                                          itemSku.Stmpdh_Artcod.Trim() });
                //inventoryTransfered.Usr_Vtex_Stktra = "S";
                //await _repository.Complete();

                await _repository.ProductsSKUReal.MarcarStockTransferido(cancellationToken, itemSku.Stmpdh_Tippro.Trim(), itemSku.Stmpdh_Artcod.Trim());

                _logger.Information($"Marca producto {itemSku.Stmpdh_Tippro} - {itemSku.Stmpdh_Artcod} como transferidos");
                
                

            }
           
            return itemsSku.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
