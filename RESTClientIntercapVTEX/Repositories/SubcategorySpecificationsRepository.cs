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
    public class SubcategorySpecificationsRepository : RepositoryBase<Usr_Sttcay>, ISubcategorySpecificationsRepository
    {
        public SubcategorySpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcay>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttcay>().FromSqlRaw("EXEC Alm_USR_SttcayGetForVTEX").ToListAsync();
        }
    }
}
