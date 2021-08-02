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
        public OrderHandlerRepository(DbContext context) : base(context)
        { }

        public async Task<IEnumerable<Usr_Vtexha>> GetToHandle(CancellationToken cancellationToken)
        {
            return await Context.Set<Usr_Vtexha>().Where(c=> c.Usr_Vtexha_Status == "N").ToListAsync();
        }
    }
    public class OrderHeaderRepository : RepositoryBase<Sar_Fcrmvh>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(DbContext context) : base(context)
        { }
    }
    public class OrderItemsRepository : RepositoryBase<Sar_Fcrmvi>, IOrderItemsRepository
    {
        public OrderItemsRepository(DbContext context) : base(context)
        { }
    }

    public class OrderPaymentsRepository : RepositoryBase<Usr_Dspaym>, IOrderPaymentsRepository
    {
        public OrderPaymentsRepository(DbContext context) : base(context)
        { }
    }

    public class OrderVtexRepository : RepositoryBase<Usr_Dspeml>, IOrderVtexRepository
    {
        public OrderVtexRepository(DbContext context) : base(context)
        { }
    }

    public class OrderShippingRepository : RepositoryBase<Usr_Dsship>, IOrderShippingRepository
    {
        public OrderShippingRepository(DbContext context) : base(context)
        { }

    }

    public class OrderContactsRepository : RepositoryBase<Usr_Dscont>, IOrderContactsRepository
    {
        public OrderContactsRepository(DbContext context) : base(context)
        { }
    }
}
