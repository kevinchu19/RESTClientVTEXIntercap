using RESTClientIntercapVTEX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface ISubcategorysRepository : IRepository<Usr_Sttcas>
    {
        Task<IEnumerable<Usr_Sttcas>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
