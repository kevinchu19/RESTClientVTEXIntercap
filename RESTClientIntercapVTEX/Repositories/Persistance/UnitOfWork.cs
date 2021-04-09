using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Repositories.Persistance
{
    public class UnitOfWork: IUnitOfWork
    {
        public ApiIntercapContext Context { get; }
        private ISpecificationsRepository _specifications { get; set; }

        public UnitOfWork(ApiIntercapContext context)
        {
            Context = context;
        }

        public ISpecificationsRepository Specifications
        {
            get
            {
                if (_specifications == null)
                {
                    _specifications = new SpecificationsRepository(Context);
                }
                return _specifications;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
