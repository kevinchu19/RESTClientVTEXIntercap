using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISpecificationsRepository Specifications { get; }
    }
}
