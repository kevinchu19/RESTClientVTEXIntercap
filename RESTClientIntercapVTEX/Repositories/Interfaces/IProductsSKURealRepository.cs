using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IProductsSKURealRepository : IRepository<Stmpdh_Real>
    {

        Task<IEnumerable<Stmpdh_Real>> GetSkuForInventory(CancellationToken cancellationToken, int take);
        Task<IEnumerable<Stmpdh_Real>> GetSkuForFiles(CancellationToken cancellationToken, int take);
        Task MarcarStockTransferido(CancellationToken cancellationToken, string tippro, string artcod);
    }
}
