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
    public class SpecificationsService:ServiceBase<SpecificationDTO>, IServiceVTEX
    {
        public SpecificationsService(SpecificationsClient<SpecificationDTO> client, IUnitOfWork repository, IMapper mapper):
            base(client, repository, mapper)
        {

        }

        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;

            var items = _mapper.Map<IEnumerable<Usr_Sttcaa>, IEnumerable<SpecificationDTO>>(await _repository.Specifications.GetForVTEX(cancellationToken));

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
                        succesOperation = await _client.PutAsync(item, item.Name, cancellationToken);
                        break;
                    default:
                        break;
                }

                if (succesOperation)
                {
                    Usr_Sttcaa specificationTransfered = await _repository.Specifications.Get(cancellationToken, item.RowId);
                    specificationTransfered.Usr_Vtex_Transf = "S";
                     
                    await _repository.Complete();
                }
                else
                {
                    Usr_Sttcaa specificationTransfered = await _repository.Specifications.Get(cancellationToken, item.RowId);
                    specificationTransfered.Usr_Vtex_Transf = "E";

                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
