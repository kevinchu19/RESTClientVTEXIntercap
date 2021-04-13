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
    public class CategorysService : ServiceBase<CategoryDTO>, IServiceVTEX
    {
        public SpecificationGroupClient<SpecificationGroupDTO> _clientSpecificationGroup { get; }

        public CategorysService(CategorysClient<CategoryDTO> client, 
                                IUnitOfWork repository, 
                                IMapper mapper, 
                                SpecificationGroupClient<SpecificationGroupDTO> clientSpecificationGroup) :
            base(client, repository, mapper)
        {
            _clientSpecificationGroup = clientSpecificationGroup;
        }

        

        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;

            var departments = _mapper.Map<IEnumerable<Usr_Sttcah>, IEnumerable<CategoryDTO>>(await _repository.Departments.GetForVTEX(cancellationToken));
            var categorys  = _mapper.Map<IEnumerable<Usr_Sttcai>, IEnumerable<CategoryDTO>>(await _repository.Categorys.GetForVTEX(cancellationToken));
            var subcategorys = _mapper.Map<IEnumerable<Usr_Sttcas>, IEnumerable<CategoryDTO>>(await _repository.Subcategorys.GetForVTEX(cancellationToken));

            IEnumerable<CategoryDTO> items = departments.Concat(categorys).Concat(subcategorys).OrderBy(c => c.Sfl_LoginDateTime);
            
            if (!items.Any()) return false;

            foreach (var item in items)
            {
                // Put in your internal queue to process async
                // It is not recommend to process direct here, if your systems start to get slow the item will be visible in the queue and you will process more the one time
                switch (item.Sfl_TableOperation)
                {
                    case "INSERT":
                        succesOperation = await _client.PostAsync(item, cancellationToken);
                        if (succesOperation)
                        {
                            await _clientSpecificationGroup.PostAsync(new SpecificationGroupDTO() { 
                                CategoryId = item.Id,
                                Id = 1,
                                Name = "UNICO"
                            } , cancellationToken);
                        }
                        
                        break;
                    case "UPDATE":
                        succesOperation = await _client.PutAsync(item, item.Id.ToString(), cancellationToken);
                        break;
                    default:
                        break;
                }

                if (succesOperation)
                {
                    switch (item.Usr_St_Oalias)
                    {
                        case "USR_STTCAH":
                            Usr_Sttcah departmentTransfered = await _repository.Departments.Get(cancellationToken,item.RowId);
                            departmentTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STTCAI":
                            Usr_Sttcai categoryTransfered = await _repository.Categorys.Get(cancellationToken, item.RowId);
                            categoryTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STTCAS":
                            Usr_Sttcas subcategoryTransfered = await _repository.Subcategorys.Get(cancellationToken, item.RowId);
                            subcategoryTransfered.Usr_Vtex_Transf = "S";
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
                        case "USR_STTCAH":
                            Usr_Sttcah departmentTransfered = await _repository.Departments.Get(cancellationToken, item.RowId);
                            departmentTransfered.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STTCAI":
                            Usr_Sttcai categoryTransfered = await _repository.Categorys.Get(cancellationToken, item.RowId);
                            categoryTransfered.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STTCAS":
                            Usr_Sttcas subcategoryTransfered = await _repository.Subcategorys.Get(cancellationToken, item.RowId);
                            subcategoryTransfered.Usr_Vtex_Transf = "E";
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
