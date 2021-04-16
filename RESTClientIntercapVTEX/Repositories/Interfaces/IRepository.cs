using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(CancellationToken cancellationToken, object[] id);
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);

        Task Add(CancellationToken cancellationToken, TEntity entity);
        Task AddRange(CancellationToken cancellationToken, IEnumerable<TEntity> entities);

        void Remove(CancellationToken cancellationToken, TEntity entity);
        void RemoveRange(CancellationToken cancellationToken, IEnumerable<TEntity> entities);
    }
}
