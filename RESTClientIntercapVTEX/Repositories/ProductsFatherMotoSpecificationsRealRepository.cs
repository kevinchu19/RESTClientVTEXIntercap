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
    public class ProductsFatherMotoSpecificationsRealRepository : RepositoryBase<Usr_Pratrm_Real>, IProductsFatherMotoSpecificationsRealRepository
    {
        public ProductsFatherMotoSpecificationsRealRepository(ApiIntercapContext context) : base(context)
        { }
    }
}
