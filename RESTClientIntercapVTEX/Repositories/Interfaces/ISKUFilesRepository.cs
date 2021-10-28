using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface ISKUFilesRepository : IRepository<Usr_Stimpr>
    {
        Task<IEnumerable<Usr_Stimpr>> GetForVTEX(CancellationToken cancellationToken, int? limit);
    }
}
