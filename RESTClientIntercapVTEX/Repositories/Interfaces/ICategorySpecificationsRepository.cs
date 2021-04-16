using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface ICategorySpecificationsRepository : IRepository<Usr_Sttcax>
    {
        Task<IEnumerable<Usr_Sttcax>> GetForVTEX(CancellationToken cancellationToken);
    }
}
