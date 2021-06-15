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
            VTEXNewIDResponse succesOperationWithNewID = new VTEXNewIDResponse();

            var departmentSpecification = _mapper.Map<IEnumerable<Usr_Sttcaa>, IEnumerable<SpecificationDTO>>(await _repository.DepartmentsSpecifications.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            var categorySpecification = _mapper.Map<IEnumerable<Usr_Sttcax>, IEnumerable<SpecificationDTO>>(await _repository.CategorySpecifications.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            var subcategorySpecification = _mapper.Map<IEnumerable<Usr_Sttcay>, IEnumerable<SpecificationDTO>>(await _repository.SubcategorySpecifications.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

            IEnumerable<SpecificationDTO> items = departmentSpecification.Concat(categorySpecification).Concat(subcategorySpecification).OrderBy(c => c.Sfl_LoginDateTime).Take(MAX_ELEMENTS_IN_QUEUE);
            
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
                    switch (item.Usr_St_Oalias)
                    {
                        case "USR_STTCAA":
                            Usr_Sttcaa DepartmentSpecificationTransfered = await _repository.DepartmentsSpecifications.Get(cancellationToken, new object[] { item.RowId });
                            Usr_Sttcaa_Real DepartmentSpecificationReal = await _repository.DepartmentsSpecificationsReal 
                                                                                    .Get(cancellationToken, new object[] { DepartmentSpecificationTransfered.Usr_Sttcaa_Deptos.Trim(),
                                                                                                                           DepartmentSpecificationTransfered.Usr_Sttcaa_Nombre.Trim()});
                            DepartmentSpecificationTransfered.Usr_Vtex_Transf = "S";
                            if (succesOperationWithNewID.Success)
                            {
                                DepartmentSpecificationReal.Usr_Sttcaa_Idvtex = succesOperationWithNewID.NewId;
                            }
                            await _repository.Complete();
                            break;
                        case "USR_STTCAX":
                            Usr_Sttcax CategorySpecificationTransfered = await _repository.CategorySpecifications.Get(cancellationToken, new object[] { item.RowId });
                            Usr_Sttcax_Real CategorySpecificationReal = await _repository.CategorySpecificationsReal
                                                                                    .Get(cancellationToken, new object[] { CategorySpecificationTransfered.Usr_Sttcax_Deptos,
                                                                                                                           CategorySpecificationTransfered.Usr_Sttcax_Catego,
                                                                                                                           CategorySpecificationTransfered.Usr_Sttcax_Nombre}); ;
                            CategorySpecificationTransfered.Usr_Vtex_Transf = "S";
                            if (succesOperationWithNewID.Success)
                            {
                                CategorySpecificationReal.Usr_Sttcax_Idvtex = succesOperationWithNewID.NewId;
                            }
                            await _repository.Complete();
                            break;
                        case "USR_STTCAY":
                            Usr_Sttcay SubcategorySpecificationTransfered = await _repository.SubcategorySpecifications.Get(cancellationToken, new object[] { item.RowId });
                            Usr_Sttcay_Real SubcategorySpecificationReal = await _repository.SubcategorySpecificationsReal
                                                                                    .Get(cancellationToken, new object[] { SubcategorySpecificationTransfered.Usr_Sttcay_Deptos,
                                                                                                                           SubcategorySpecificationTransfered.Usr_Sttcay_Catego,
                                                                                                                           SubcategorySpecificationTransfered.Usr_Sttcay_Subcat,
                                                                                                                           SubcategorySpecificationTransfered.Usr_Sttcay_Nombre});
                            SubcategorySpecificationTransfered.Usr_Vtex_Transf = "S";
                            if (succesOperationWithNewID.Success)
                            {
                                SubcategorySpecificationReal.Usr_Sttcay_Idvtex = succesOperationWithNewID.NewId;
                            }
                            await _repository.Complete();
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
