using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IProductsFatherSpecificationsRepository : IRepository<Usr_Stmppa>
    {
        Task<IEnumerable<Usr_Stmppa>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
