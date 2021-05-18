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
    public class SpecificationValuesRepository : RepositoryBase<Usr_Sttvai>, ISpecificationValueRepository
    {
        public SpecificationValuesRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Sttvai>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Sttvai>().FromSqlRaw("EXEC Alm_USR_SttvaiGetForVTEX").ToListAsync();
        }
    }
}
