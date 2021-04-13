using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories
{
    public class SpecificationsRepository: RepositoryBase<Usr_Sttcaa>, ISpecificationsRepository
    {
        public SpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcaa>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttcaa>().FromSqlRaw("EXEC Alm_USR_STTCAAGetForVTEX").ToListAsync();
        }
    }
}
