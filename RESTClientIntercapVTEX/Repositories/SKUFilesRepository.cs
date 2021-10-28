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
    public class SKUFilesRepository : RepositoryBase<Usr_Stimpr>, ISKUFilesRepository
    {
        public SKUFilesRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Stimpr>> GetForVTEX(CancellationToken cancellationToken, int? skuId)
        {
            return await Context.Set<Usr_Stimpr>().FromSqlInterpolated($"EXEC Alm_USR_StimprGetForVTEX {skuId}").ToListAsync();
        }
    }
}
