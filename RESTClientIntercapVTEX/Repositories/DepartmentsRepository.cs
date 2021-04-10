
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Repositories
{
    public class DepartmentsRepository : RepositoryBase<Usr_Sttcah>, IDepartmentsRepository
    {
        public DepartmentsRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
