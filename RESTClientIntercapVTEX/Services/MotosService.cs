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
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            var items = _mapper.Map<IEnumerable<Usr_Prmoto>, IEnumerable<MotosDocumentDTO>>(await _repository.Motos.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

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
                        succesOperation = await _client.PutAsync(item, item.DocumentId.ToString(), cancellationToken);
                        break;
                    case "DELETE":
                        succesOperation = await _client.DeleteAsync(item.DocumentId.ToString(), cancellationToken);
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {
                    if (item.RowId != 0) //Moto sin año hasta
                    {
                        Usr_Prmoto motoTransfered = await _repository.Motos.Get(cancellationToken, new object[] { item.RowId });
                        motoTransfered.Usr_Vtex_Transf = "S";
                        motoTransfered.Usr_Prmoto_Idvtex = succesOperationWithNewID.NewIdString;
                    }
                        
                    Usr_Prmoto_Real motoReal = await _repository.MotosReal.Get(cancellationToken, new object[] { item.idERP});

                    motoReal.Usr_Prmoto_Idvtex = succesOperationWithNewID.NewIdString ?? item.DocumentId;

                    if (item.anios != null && item.anios != "")
                    {
                        motoReal.Usr_Vtex_Anohastra = Convert.ToInt32(item.anios.Split("-")[item.anios.Split("-").Length-1]);
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
