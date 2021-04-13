using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }
        public async Task<TEntity> Get(CancellationToken cancellationToken, int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken) => await Context.Set<TEntity>()
                                                                         .ToListAsync();

        public async Task Add(CancellationToken cancellationToken, TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public async Task AddRange(CancellationToken cancellationToken, IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);


        public void Remove(CancellationToken cancellationToken, TEntity entity) => Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(CancellationToken cancellationToken, IEnumerable<TEntity> entities) => Context.Set<TEntity>().RemoveRange(entities);
    }

}
