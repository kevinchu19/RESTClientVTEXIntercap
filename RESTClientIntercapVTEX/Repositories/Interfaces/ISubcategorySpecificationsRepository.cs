using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface ISubcategorySpecificationsRepository : IRepository<Usr_Sttcay>
    {
        Task<IEnumerable<Usr_Sttcay>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
