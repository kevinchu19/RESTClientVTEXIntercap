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
    public class SpecificationValuesRealRepository : RepositoryBase<Usr_Sttvai_Real>, ISpecificationValueRealRepository
    {
        public SpecificationValuesRealRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
