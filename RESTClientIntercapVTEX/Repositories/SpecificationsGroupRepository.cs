using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace RESTClientIntercapVTEX.Repositories
{
    public class SpecificationsGroupRepository : RepositoryBase<Usr_Sttgsh>, ISpecificationsGroupRepository
    {
        public SpecificationsGroupRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttgsh>> GetForVTEX(CancellationToken cancellationToken, int limit)
        {
            return await Context.Set<Usr_Sttgsh>().FromSqlInterpolated($"EXEC Alm_USR_SttgshGetForVTEX {limit}").ToListAsync();
        }
    }
}
