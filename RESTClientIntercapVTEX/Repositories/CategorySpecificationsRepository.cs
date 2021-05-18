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
    public class CategorySpecificationsRepository : RepositoryBase<Usr_Sttcax>, ICategorySpecificationsRepository
    {
        public CategorySpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttcax>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttcax>().FromSqlRaw("EXEC Alm_USR_SttcaxGetForVTEX").ToListAsync();
        }
    }
}
