using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IProductsFatherRepository : IRepository<Usr_Stmpph>
    {
        Task<IEnumerable<Usr_Stmpph>> GetForVTEX(CancellationToken cancellationToken);
    }
}
