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
    public class SpecificationValuesService : ServiceBase<SpecificationValueDTO>, IServiceVTEX
    {
        
        public SpecificationValuesService(SpecificationValuesClient<SpecificationValueDTO> client,
                                IUnitOfWork repository,
                                IMapper mapper) :
            base(client, repository, mapper)
        {}



        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            var items = _mapper.Map<IEnumerable<Usr_Sttvai>, IEnumerable<SpecificationValueDTO>>(await _repository.SpecificationValues.GetForVTEX(cancellationToken));
            
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
                        if (item.FieldValueId == 0) //Quiere decir que no se dio de alta en vtex aun
                        {
                            succesOperationWithNewID = await _client.PostWithNewIDAsync(item, cancellationToken);
                        }
                        else
                        {
                            succesOperation = await _client.PutAsync(item, item.FieldValueId.ToString(), cancellationToken);
                        }
                        break;
                    default:
                        break;
                }

                if (succesOperation || succesOperationWithNewID.Success)
                {
                       
                    Usr_Sttvai specificationValueTransfered = await _repository.SpecificationValues.Get(cancellationToken, new object[] {item.RowId});
                    Usr_Sttvai_Real specificationValueReal= await _repository.SpecificationValuesReal.Get(cancellationToken, new object[] { specificationValueTransfered.Usr_Sttvai_Deptos.Trim(),
                                                                                                                                            specificationValueTransfered.Usr_Sttvai_Catego.Trim(),
                                                                                                                                            specificationValueTransfered.Usr_Sttvai_Subcat.Trim(),
                                                                                                                                            specificationValueTransfered.Usr_Sttvai_Fielid,
                                                                                                                                            specificationValueTransfered.Usr_Sttvai_Valor});
                    specificationValueTransfered.Usr_Vtex_Transf = "S";
                    if (succesOperationWithNewID.Success)
                    {
                        specificationValueReal.Usr_Sttvai_Idvtex = succesOperationWithNewID.NewId;
                    }
                    await _repository.Complete();
                }
                else
                {
                    Usr_Sttvai specificationValueTransfered  = await _repository.SpecificationValues.Get(cancellationToken, new object[] {item.RowId});
                    specificationValueTransfered.Usr_Vtex_Transf = "E";
                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
