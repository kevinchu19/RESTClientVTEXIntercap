
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Repositories
{
    public class SubcategorysRepository : RepositoryBase<Usr_Sttcas>, ISubcategorysRepository
    {
        public SubcategorysRepository(ApiIntercapContext context) : base(context)
        { }

    }

}