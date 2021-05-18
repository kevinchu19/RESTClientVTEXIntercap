
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories
{
    public class SubcategorysRepository : RepositoryBase<Usr_Sttcas>, ISubcategorysRepository
    {
        public SubcategorysRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcas>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttcas>().FromSqlRaw("EXEC Alm_USR_STTCASGetForVTEX").ToListAsync();
        }
    }

}