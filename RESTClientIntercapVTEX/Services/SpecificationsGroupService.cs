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
    public class SpecificationsGroupService : ServiceBase<SpecificationGroupDTO>, IServiceVTEX
    {

        public SpecificationsGroupService(SpecificationGroupClient<SpecificationGroupDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        { }



        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            var items = _mapper.Map<IEnumerable<Usr_Sttgsh>, IEnumerable<SpecificationGroupDTO>>(await _repository.SpecificationsGroup.GetForVTEX(cancellationToken));

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
                        if (item.Id == 0) //Quiere decir que no se dio de alta en vtex aun
                        {
                            succesOperationWithNewID = await _client.PostWithNewIDAsync(item, cancellationToken);
                        }
                        else
                        {
                            succesOperation = await _client.PutAsync(item, item.Id.ToString(), cancellationToken);
                        }
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {

                    Usr_Sttgsh SpecificationGroupTransfered = await _repository.SpecificationsGroup.Get(cancellationToken, new object[] { item.RowId});
                    Usr_Sttgsh_Real SpecificationGroupReal = await _repository.SpecificationsGroupReal
                                                                            .Get(cancellationToken, new object[] { SpecificationGroupTransfered.Usr_Sttgsh_Deptos,
                                                                                                                   SpecificationGroupTransfered.Usr_Sttgsh_Catego,
                                                                                                                   SpecificationGroupTransfered.Usr_Sttgsh_Subcat,
                                                                                                                   SpecificationGroupTransfered.Usr_Sttgsh_Nombre});
                    SpecificationGroupTransfered.Usr_Vtex_Transf = "S";
                    if (succesOperationWithNewID.Success)
                    {
                        SpecificationGroupReal.Usr_Sttgsh_Idvtex = succesOperationWithNewID.NewId;
                    }
                    await _repository.Complete();
                }
                else
                {
                    Usr_Sttgsh SpecificationGroupTransfered = await _repository.SpecificationsGroup.Get(cancellationToken, new object[] {item.RowId});
                    SpecificationGroupTransfered.Usr_Vtex_Transf = "E";
                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
