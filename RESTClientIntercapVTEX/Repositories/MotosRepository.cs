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
    public class MotosRepository : RepositoryBase<Usr_Prmoto>, IMotosRepository
    {
        public MotosRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Prmoto>> GetForVTEX(CancellationToken cancellationToken, int limit)
        {
            return await Context.Set<Usr_Prmoto>().FromSqlInterpolated($"EXEC Alm_USR_PRMOTOGetForVTEX {limit}").ToListAsync();
        }
    }
}
