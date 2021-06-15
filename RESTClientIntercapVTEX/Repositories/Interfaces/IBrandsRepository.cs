using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IBrandsRepository : IRepository<Usr_Sttmah>
    {
        Task<IEnumerable<Usr_Sttmah>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
