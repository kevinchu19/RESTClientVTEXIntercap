using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Repositories
{
    public class SpecificationsRepository: RepositoryBase<Usr_Sttcaa>, ISpecificationsRepository
    {
        public SpecificationsRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
