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
    public class ProductsFatherRepository : RepositoryBase<Usr_Stmpph>, IProductsFatherRepository
    {
        public ProductsFatherRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Stmpph>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Stmpph>().FromSqlRaw("EXEC Alm_USR_StmpphGetForVTEX").ToListAsync();
        }
    }
}
