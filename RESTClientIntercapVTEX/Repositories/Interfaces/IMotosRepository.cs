using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IMotosRepository : IRepository<Usr_Prmoto>
    {
        Task<IEnumerable<Usr_Prmoto>> GetForVTEX(CancellationToken cancellationToken, int limit);
    }
}
