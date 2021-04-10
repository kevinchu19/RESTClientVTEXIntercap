
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Repositories
{
    public class CategorysRepository : RepositoryBase<Usr_Sttcai>, ICategorysRepository
    {
        public CategorysRepository(ApiIntercapContext context) : base(context)
        { }

    }
}
