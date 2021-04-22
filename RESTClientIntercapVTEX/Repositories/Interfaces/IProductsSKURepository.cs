﻿using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IProductsSKURepository : IRepository<Stmpdh>
    {
        Task<IEnumerable<Stmpdh>> GetProductForVTEX(CancellationToken cancellationToken);
        Task<IEnumerable<Stmpdh>> GetSKUForVTEX(CancellationToken cancellationToken);
    }
}
