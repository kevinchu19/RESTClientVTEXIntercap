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
    public class CategorysRepository : RepositoryBase<Usr_Sttcai>, ICategorysRepository
    {
        public CategorysRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcai>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttcai>().FromSqlRaw("EXEC Alm_USR_STTCAIGetForVTEX").ToListAsync();
        }
    }
}
