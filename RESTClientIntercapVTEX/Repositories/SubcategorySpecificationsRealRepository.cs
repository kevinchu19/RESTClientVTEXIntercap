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
    public class SubcategorySpecificationsRealRepository : RepositoryBase<Usr_Sttcay_Real>, ISubcategorySpecificationsRealRepository
    {
        public SubcategorySpecificationsRealRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
