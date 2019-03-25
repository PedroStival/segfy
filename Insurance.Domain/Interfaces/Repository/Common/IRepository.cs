using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Insurance.Domain.Entities.Common;

namespace Insurance.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity> : IDisposable
          where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> All();
        TEntity Get(long id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Include(IEnumerable<TEntity> entities,
            params Expression<Func<TEntity, ICollection<EntityBase>>>[] properties);
        TEntity Include(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> Include(IEnumerable<TEntity> entities, params Expression<Func<TEntity, object>>[] includeProperties);
        void ExecuteQuery(string query);
        IEnumerable<TEntity> Query(string query);
    }
}
