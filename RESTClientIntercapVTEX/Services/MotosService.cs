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
    public class MotosService : ServiceBase<MotosDocumentDTO>, IServiceVTEX
    {

        public MotosService(MotosClient<MotosDocumentDTO> client,
                                IUnitOfWorkProduccion repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        { }



        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;

            var items = _mapper.Map<IEnumerable<Usr_Prmoto>, IEnumerable<MotosDocumentDTO>>(await _repository.Motos.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

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
                        succesOperation = await _client.PutAsync(item, item.idERP.ToString(), cancellationToken);
                        break;
                    case "DELETE":
                        succesOperation = await _client.DeleteAsync(item.idERP.ToString(), cancellationToken);
                        break;
                    default:
                        break;
                }

                if (succesOperation)
                {

                    Usr_Prmoto motoTransfered = await _repository.Motos.Get(cancellationToken, new object[] { item.RowId });
                    Usr_Prmoto_Real motoReal = await _repository.MotosReal.Get(cancellationToken, new object[] { motoTransfered.Usr_Prmoto_Idmoto});

                    motoTransfered.Usr_Vtex_Transf = "S";
                    if (item.anios.Any())
                    {
                        motoReal.Usr_Vtex_Anohastra = item.anios.Max();
                    } else
                    {
                        motoReal.Usr_Vtex_Anohastra = DateTime.Now.Year;
                    }
                    

                    await _repository.Complete();
                }
                else
                {
                    Usr_Prmoto motoTransfered = await _repository.Motos.Get(cancellationToken, new object[] { item.RowId });
                    motoTransfered.Usr_Vtex_Transf = "E";
                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
