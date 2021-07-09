using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Models;

namespace RESTClientIntercapVTEX.Services
{
    internal class FeedService
    {

        const int MAX_ELEMENTS_IN_QUEUE = 10;

        private readonly FeedClient<FeedDTO> _feedClient;

        public FeedService(FeedClient<FeedDTO> feedClient)
        {
            this._feedClient = feedClient;
        }

        /// <summary>
        /// Create the task and invoke the feedClient
        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>
        internal async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            var items = await _feedClient.DequeueAsync(cancellationToken);

            if (!items.Any()) return false;

            foreach (var item in items)
            {
                var a = 1;
                // Put in your internal queue to process async
                // It is not recommend to process direct here, if your systems start to get slow the item will be visible in the queue and you will process more the one time
            }

            //await _feedClient.CommitAsync(items.Select(item => item.Handle), cancellationToken);

            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }

    }
}
