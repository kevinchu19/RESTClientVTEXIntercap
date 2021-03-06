using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IDepartmentSpecificationsRepository : IRepository<Usr_Sttcaa>
    {
        Task<IEnumerable<Usr_Sttcaa>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
