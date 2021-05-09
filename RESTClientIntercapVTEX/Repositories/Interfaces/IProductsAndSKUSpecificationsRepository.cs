using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IProductsAndSKUSpecificationsRepository : IRepository<Usr_Pratri>
    {
        Task<IEnumerable<Usr_Pratri>> GetProductSpecificationForVTEX(CancellationToken cancellationToken);
        Task<IEnumerable<Usr_Pratri>> GetSKUSpecificationForVTEX(CancellationToken cancellationToken);
    }
}
