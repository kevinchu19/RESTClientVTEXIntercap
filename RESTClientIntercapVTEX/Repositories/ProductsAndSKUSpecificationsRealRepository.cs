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
    public class ProductsAndSKUSpecificationsRealRepository : RepositoryBase<Usr_Pratri_Real>, IProductsAndSKUSpecificationsRealRepository
    {
        public ProductsAndSKUSpecificationsRealRepository(ApiIntercapContext context) : base(context)
        { }
    }
}
