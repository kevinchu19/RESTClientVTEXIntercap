using RESTClientIntercapVTEX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface ICategorysRepository : IRepository<Usr_Sttcai>
    {
        Task<IEnumerable<Usr_Sttcai>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }

    
}
