
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
    public class SubcategorysRepository : RepositoryBase<Usr_Sttcas>, ISubcategorysRepository
    {
        public SubcategorysRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcas>> GetForVTEX(CancellationToken cancellationToken, int limit)
        {
            return await Context.Set<Usr_Sttcas>().FromSqlInterpolated($"EXEC Alm_USR_STTCASGetForVTEX {limit}").ToListAsync();
        }
    }

}