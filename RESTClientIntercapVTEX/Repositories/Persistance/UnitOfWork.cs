using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Persistance
{
    public class UnitOfWork: IUnitOfWork
    {
        public ApiIntercapContext Context { get; }
        private ISpecificationsRepository _specifications { get; set; }
        public IDepartmentsRepository _departments { get; set; }

        public ICategorysRepository _categorys { get; set; }

        public ISubcategorysRepository _subcategorys { get; set; }


        public UnitOfWork(ApiIntercapContext context)
        {
            Context = context;
        }

        public IDepartmentsRepository Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentsRepository(Context);
                }
                return _departments;
            }
        }

        public ICategorysRepository Categorys
        {
            get
            {
                if (_categorys == null)
                {
                    _categorys = new CategorysRepository(Context);
                }
                return _categorys;
            }
        }
        public ISubcategorysRepository Subcategorys
        {
            get
            {
                if (_subcategorys == null)
                {
                    _subcategorys = new SubcategorysRepository(Context);
                }
                return _subcategorys;
            }
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

        public async Task<int> Complete()
        {
            return await Context.SaveChangesAsync();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
