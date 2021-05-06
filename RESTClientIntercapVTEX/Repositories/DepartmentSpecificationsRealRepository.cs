using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories
{
    public class DepartmentSpecificationsRealRepository: RepositoryBase<Usr_Sttcaa>, IDepartmentSpecificationsRealRepository
    {
        public DepartmentSpecificationsRealRepository(ApiIntercapContext context) : base(context)
        { }

       
    }
}
