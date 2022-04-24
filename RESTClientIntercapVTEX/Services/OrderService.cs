//TODO: Modificar status de USR_VTEXHA para que no vuelva a solicitar el pedido
//TODO: Insertar tablas USR_DSPEML
//TODO: Commit en feed service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RESTClientIntercapVTEX.Builder;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models.Order;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using RESTClientIntercapVTEX.Repositories.Persistance;
using RESTClientIntercapVTEX.Services.Interfaces;
using Serilog;

namespace RESTClientIntercapVTEX.Services
{
    internal class OrderService : ServiceBase<OrderDTO>, IServiceVTEX
    {

        private readonly OrderClient<OrderDTO> _orderClient;        
        private ILogger _logger;

        public OrderService(OrderClient<OrderDTO> orderClient, IUnitOfWorkTest repository,IMapper mapper, Serilog.ILogger logger):
            base(orderClient, repository, mapper)
        {
            _orderClient = orderClient;
            _logger = logger;
        }

        /// <summary>
        /// Create the task and invoke the orderClient
        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>
        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {

            List<Sar_Fcrmvh> ordersToInsert = new List<Sar_Fcrmvh>();
            List<Usr_Dspeml> ordersToInsertDs = new List<Usr_Dspeml>();

            IEnumerable<Usr_Vtexha> items = await _repository.OrderHandlerRepository.GetToHandle(cancellationToken);
            
            if (!items.Any()) return false;

            foreach (Usr_Vtexha orderToHandle in items)
            {
                Sar_Fcrmvh orderCreada = await _repository.OrderHeaderRepository.Get(cancellationToken, new object[] { orderToHandle.Usr_Vtexha_Ordid });
                if (orderCreada == null)
                {
                    OrderDTO order = await _orderClient.DequeueOrderAsync(cancellationToken, orderToHandle.Usr_Vtexha_Ordid);
                    _logger.Information($"Se recuperó la orden {order.orderId} y fue cargada para su procesamiento.");

                    ordersToInsert.Add(new SarFcrmvhBuilder()
                                            .setHeader(order)
                                            .addItems(order.orderId,order.items, order.shippingData)
                                            .Build());
                    ordersToInsertDs.Add(new UsrDspemlBuilder()
                                            .setHeader(order)
                                            .addContacts(order.clientProfileData, order.shippingData.address)
                                            .addPayments(order.paymentData.transactions)
                                            .Build());
                    
                }
                
            }
            try
            {

                await _repository.OrderHeaderRepository.AddRange(cancellationToken, ordersToInsert);
                await _repository.OrderVtexRepository.AddRange(cancellationToken, ordersToInsertDs);
                await _repository.Complete();
            
            }
            catch (Exception ex )
            {
                _logger.Fatal($"Error al insertar ordenes: {ex.InnerException.Message}");
            }

            //await _orderClient.CommitAsync(items.Select(item => item.Handle), cancellationToken);

            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }

    }
}
