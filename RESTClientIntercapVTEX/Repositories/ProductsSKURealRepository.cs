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
    public class ProductsSKURealRepository : RepositoryBase<Stmpdh_Real>, IProductsSKURealRepository
    {
        public ProductsSKURealRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Stmpdh_Real>> GetSkuForInventory (CancellationToken cancellationToken, int take) => await Context.Set<Stmpdh_Real>()
            .Where(c=> c.Usr_Vtex_Stktra != "S" && c.Usr_Stmpdh_IdSKUvtex != 0)
            .Take(take)
            .ToListAsync();

        public async Task<IEnumerable<Stmpdh_Real>> GetSkuForFiles(CancellationToken cancellationToken, int take) => await Context.Set<Stmpdh_Real>()
            .Where(c => c.Usr_Vtex_Imgtra != "S" && c.Usr_Stmpdh_IdSKUvtex != 0)
            .Take(take)
            .ToListAsync();

    }
}
