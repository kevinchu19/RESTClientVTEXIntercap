using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace RESTClientIntercapVTEX.Repositories
{
    public class SpecificationsGroupRepository : RepositoryBase<Usr_Sttgsh>, ISpecificationsGroupRepository
    {
        public SpecificationsGroupRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttgsh>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttgsh>().FromSqlRaw("EXEC Alm_USR_SttgshGetForVTEX").ToListAsync();
        }
    }
}
