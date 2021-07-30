using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using Serilog;

namespace RESTClientIntercapVTEX.Services
{
    internal class FeedService
    {

        const int MAX_ELEMENTS_IN_QUEUE = 10;

        private readonly FeedClient<FeedDTO> _feedClient;
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private ILogger _logger;

        public FeedService(FeedClient<FeedDTO> feedClient, IUnitOfWork repository,IMapper mapper, Serilog.ILogger logger)
        {
            _feedClient = feedClient;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Create the task and invoke the feedClient
        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>
        internal async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            IEnumerable<FeedDTO> feedItems = await _feedClient.DequeueAsync(cancellationToken);
            IEnumerable<Usr_Vtexha> items = _mapper.Map<IEnumerable<FeedDTO>, IEnumerable<Usr_Vtexha>>(feedItems);

            if (!items.Any()) return false;

            foreach (Usr_Vtexha item in items)
            {
                Usr_Vtexha orderHandleada = await _repository.OrderHandlerRepository.Get(cancellationToken,new object[] { item.Usr_Vtexha_Ordid });
                if (orderHandleada == null)
                {
                    await _repository.OrderHandlerRepository.Add(cancellationToken, item);
                    await _repository.Complete();
                    _logger.Information($"Se recuperó la orden {item.Usr_Vtexha_Ordid} para ser handleada.");
                }
                
            }

            //await _feedClient.CommitAsync(items.Select(item => item.Handle), cancellationToken);

            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }

    }
}
