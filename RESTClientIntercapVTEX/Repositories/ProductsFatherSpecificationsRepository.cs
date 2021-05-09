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
    public class ProductsFatherSpecificationsRepository : RepositoryBase<Usr_Stmppa>, IProductsFatherSpecificationsRepository
    {
        public ProductsFatherSpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Stmppa>> GetForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Stmppa>().FromSqlRaw("EXEC Alm_USR_STMPPAGetForVTEX").ToListAsync();
        }

    }
}
