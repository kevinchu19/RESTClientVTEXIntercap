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
    public class ProductsAndSKUSpecificationsRepository : RepositoryBase<Usr_Pratri>, IProductsAndSKUSpecificationsRepository
    {
        public ProductsAndSKUSpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

        
        public async Task<IEnumerable<Usr_Pratri>> GetProductSpecificationForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Pratri>().FromSqlRaw("EXEC Alm_USR_PRATRIProductGetForVTEX").ToListAsync();
        }

        public async Task<IEnumerable<Usr_Pratri>> GetSKUSpecificationForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Pratri>().FromSqlRaw("EXEC Alm_USR_PRATRISKUGetForVTEX").ToListAsync();
        }
    }
}
