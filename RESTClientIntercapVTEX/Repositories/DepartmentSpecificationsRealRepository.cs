using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories
{
    public class DepartmentSpecificationsRealRepository: RepositoryBase<Usr_Sttcaa_Real>, IDepartmentSpecificationsRealRepository
    {
        public DepartmentSpecificationsRealRepository(ApiIntercapContext context) : base(context)
        { }

       
    }
}
