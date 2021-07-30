using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IOrderHandlerRepository : IRepository<Usr_Vtexha>
    {
        Task<IEnumerable<Usr_Vtexha>> GetToHandle(CancellationToken cancellationToken);
    }
    public interface IOrderHeaderRepository : IRepository<Sar_Fcrmvh>
    { }
    public interface IOrderItemsRepository : IRepository<Sar_Fcrmvi>
    { }
    public interface IOrderPaymentsRepository : IRepository<Sar_Fcrmvt>
    { }
}
