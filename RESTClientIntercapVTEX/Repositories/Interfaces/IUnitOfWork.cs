using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISpecificationsRepository Specifications { get; }
        IDepartmentsRepository Departments { get; }
        ICategorysRepository Categorys { get; }
        ISubcategorysRepository Subcategorys { get; }
        Task<int> Complete();

    }
}
