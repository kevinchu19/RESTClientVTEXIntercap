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
        public CategorysService(CategorysClient<CategoryDTO> client, 
                                IUnitOfWorkProduccion repository, 
                                IMapper mapper) :
            base(client, repository, mapper)
        {}

        

        /// </summary>
        /// <returns>Return true if there is more elements in the queue</returns>

        public async Task<bool> DequeueProcessAndCheckIfContinueAsync(CancellationToken cancellationToken)
        {
            bool succesOperation = false;

            var Categorys = _mapper.Map<IEnumerable<Usr_Sttcah>, IEnumerable<CategoryDTO>>(await _repository.Departments.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            var categorys  = _mapper.Map<IEnumerable<Usr_Sttcai>, IEnumerable<CategoryDTO>>(await _repository.Categorys.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));
            var subcategorys = _mapper.Map<IEnumerable<Usr_Sttcas>, IEnumerable<CategoryDTO>>(await _repository.Subcategorys.GetForVTEX(cancellationToken, MAX_ELEMENTS_IN_QUEUE));

            IEnumerable<CategoryDTO> items = Categorys.Concat(categorys).Concat(subcategorys).OrderBy(c => c.Sfl_LoginDateTime).Take(MAX_ELEMENTS_IN_QUEUE);
            
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
                            Usr_Sttcah DepartmentTransfered = await _repository.Departments.Get(cancellationToken, new object[] {item.RowId});
                            DepartmentTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STTCAI":
                            Usr_Sttcai categoryTransfered = await _repository.Categorys.Get(cancellationToken, new object[] {item.RowId});
                            categoryTransfered.Usr_Vtex_Transf = "S";
                            break;
                        case "USR_STTCAS":
                            Usr_Sttcas subcategoryTransfered = await _repository.Subcategorys.Get(cancellationToken, new object[] {item.RowId});
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
                            Usr_Sttcah departmentTransfered = await _repository.Departments.Get(cancellationToken, new object[] {item.RowId});
                            departmentTransfered.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STTCAI":
                            Usr_Sttcai categoryTransfered = await _repository.Categorys.Get(cancellationToken, new object[] {item.RowId});
                            categoryTransfered.Usr_Vtex_Transf = "E";
                            break;
                        case "USR_STTCAS":
                            Usr_Sttcas subcategoryTransfered = await _repository.Subcategorys.Get(cancellationToken, new object[] {item.RowId});
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
