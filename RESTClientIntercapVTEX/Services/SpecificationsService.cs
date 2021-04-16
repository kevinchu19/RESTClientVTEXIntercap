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

            var departmentSpecification = _mapper.Map<IEnumerable<Usr_Sttcaa>, IEnumerable<SpecificationDTO>>(await _repository.DepartmentsSpecifications.GetForVTEX(cancellationToken));
            var categorySpecification = _mapper.Map<IEnumerable<Usr_Sttcax>, IEnumerable<SpecificationDTO>>(await _repository.CategorySpecifications.GetForVTEX(cancellationToken));
            var subcategorySpecification = _mapper.Map<IEnumerable<Usr_Sttcay>, IEnumerable<SpecificationDTO>>(await _repository.SubcategorySpecifications.GetForVTEX(cancellationToken));

            IEnumerable<SpecificationDTO> items = departmentSpecification.Concat(categorySpecification).Concat(subcategorySpecification).OrderBy(c => c.Sfl_LoginDateTime);
            
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
                    switch (item.Usr_St_Oalias)
                    {
                        case "USR_STTCAA":
                            Usr_Sttcaa departmentSpecificationTransfered = await _repository.DepartmentsSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            departmentSpecificationTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STTCAX":
                            Usr_Sttcax categorySpecificationTransfered = await _repository.CategorySpecifications.Get(cancellationToken, new object[] { item.RowId });
                            categorySpecificationTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STTCAY":
                            Usr_Sttcay subcategorySpecificationTransfered = await _repository.SubcategorySpecifications.Get(cancellationToken, new object[] { item.RowId });
                            subcategorySpecificationTransfered.Usr_Vtex_Transf = "S";
                            break;
                        default:
                            break;
                    }
                    await _repository.Complete();
                }
                else
                {
                    switch (item.Usr_St_Oalias)
                    {
                        case "USR_STTCAA":
                            Usr_Sttcaa departmentSpecificationTransfered = await _repository.DepartmentsSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            departmentSpecificationTransfered.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STTCAX":
                            Usr_Sttcax categorySpecificationTransfered = await _repository.CategorySpecifications.Get(cancellationToken, new object[] { item.RowId });
                            categorySpecificationTransfered.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STTCAY":
                            Usr_Sttcay subcategorySpecificationTransfered = await _repository.SubcategorySpecifications.Get(cancellationToken, new object[] { item.RowId });
                            subcategorySpecificationTransfered.Usr_Vtex_Transf = "E";
                            break;
                        default:
                            break;
                    }

                    await _repository.Complete();
                }

            }
            return items.Count() == MAX_ELEMENTS_IN_QUEUE;
        }
    }
}
