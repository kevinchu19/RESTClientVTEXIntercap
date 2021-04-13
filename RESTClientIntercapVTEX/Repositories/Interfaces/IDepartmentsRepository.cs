using RESTClientIntercapVTEX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IDepartmentsRepository : IRepository<Usr_Sttcah>
    {
        Task<IEnumerable<Usr_Sttcah>> GetForVTEX(CancellationToken cancellationToken);
    }

}
