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
    public class SpecificationsGroupRealRepository : RepositoryBase<Usr_Sttgsh_Real>, ISpecificationsGroupRealRepository
    {
        public SpecificationsGroupRealRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
