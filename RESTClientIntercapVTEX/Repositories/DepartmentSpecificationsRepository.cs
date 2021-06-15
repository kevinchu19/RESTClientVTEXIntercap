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
    public class DepartmentSpecificationsRepository: RepositoryBase<Usr_Sttcaa>, IDepartmentSpecificationsRepository
    {
        public DepartmentSpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcaa>> GetForVTEX(CancellationToken cancellationToken, int limit)
        {
            return await Context.Set<Usr_Sttcaa>().FromSqlInterpolated($"EXEC Alm_USR_STTCAAGetForVTEX {limit}").ToListAsync();
        }
    }
}
