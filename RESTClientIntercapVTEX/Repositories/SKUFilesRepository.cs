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
    public class BrandsRepository : RepositoryBase<Usr_Sttmah>, IBrandsRepository
    {
        public BrandsRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttmah>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttmah>().FromSqlRaw("EXEC Alm_USR_SttmahGetForVTEX").ToListAsync();
        }
    }
}
