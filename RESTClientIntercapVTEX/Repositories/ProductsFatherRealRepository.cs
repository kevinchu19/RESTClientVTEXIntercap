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
    public class ProductsFatherRealRepository : RepositoryBase<Usr_Stmpph_Real>, IProductsFatherRealRepository
    {
        public ProductsFatherRealRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
