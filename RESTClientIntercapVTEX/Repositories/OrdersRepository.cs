using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace RESTClientIntercapVTEX.Repositories
{
    public class OrderHandlerRepository : RepositoryBase<Usr_Vtexha>, IOrderHandlerRepository
    {
        public OrderHandlerRepository(ApiIntercapContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Vtexha>> GetToHandle(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Vtexha>().Where(c=> c.Usr_Vtexha_Status == "N").ToListAsync();
        }
    }
    public class OrderHeaderRepository : RepositoryBase<Sar_Fcrmvh>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(ApiIntercapContext context) : base(context)
        { }
    }
    public class OrderItemsRepository : RepositoryBase<Sar_Fcrmvi>, IOrderItemsRepository
    {
        public OrderItemsRepository(ApiIntercapContext context) : base(context)
        { }
    }

    public class OrderPaymentsRepository : RepositoryBase<Sar_Fcrmvt>, IOrderPaymentsRepository
    {
        public OrderPaymentsRepository(ApiIntercapContext context) : base(context)
        { }
    }
}
