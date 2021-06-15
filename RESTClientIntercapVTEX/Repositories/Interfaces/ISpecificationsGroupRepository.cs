using RESTClientIntercapVTEX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{ 
    public interface ISpecificationsGroupRepository : IRepository<Usr_Sttgsh>
    {
        Task<IEnumerable<Usr_Sttgsh>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }

}
