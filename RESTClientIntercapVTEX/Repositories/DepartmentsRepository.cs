
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories
{
    public class DepartmentsRepository : RepositoryBase<Usr_Sttcah>, IDepartmentsRepository
    {
        public DepartmentsRepository(ApiIntercapContext context) : base(context)
        { }
        public async Task<IEnumerable<Usr_Sttcah>> GetForVTEX(CancellationToken cancellationToken, int limit)
        {
            return await Context.Set<Usr_Sttcah>().FromSqlInterpolated($"EXEC Alm_USR_STTCAHGetForVTEX {limit}").ToListAsync();
        }
    }
}
