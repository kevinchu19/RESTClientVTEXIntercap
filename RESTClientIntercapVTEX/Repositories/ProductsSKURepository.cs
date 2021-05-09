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
    public class ProductsSKURepository : RepositoryBase<Stmpdh>, IProductsSKURepository
    {
        public ProductsSKURepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Stmpdh>> GetProductForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Stmpdh>().FromSqlRaw("EXEC Alm_StmpdhProductGetForVTEX").ToListAsync();
        }

        public async Task<IEnumerable<Stmpdh>> GetSKUForVTEX(CancellationToken cancellationToken)
        {
            IEnumerable<Stmpdh> a = await Context.Set<Stmpdh>().FromSqlRaw("EXEC Alm_StmpdhSKUGetForVTEX").ToListAsync();
            return a;
        }
    }
}
