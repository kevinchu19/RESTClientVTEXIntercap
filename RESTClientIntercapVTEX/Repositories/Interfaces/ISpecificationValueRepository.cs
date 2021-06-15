using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface ISpecificationValueRepository : IRepository<Usr_Sttvai>
    {
        Task<IEnumerable<Usr_Sttvai>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
