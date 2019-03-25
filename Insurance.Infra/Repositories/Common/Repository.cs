using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Insurance.Domain.Entities.Common;
using Insurance.Domain.Interfaces.Repository.Common;
using Insurance.Infra.Data;
namespace Insurance.Infra.Repositories.Common
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected IDbSet<TEntity> DbSet { get; set; }
        private readonly AppDataContext _context;

        public Repository(AppDataContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return DbSet.ToList();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> Include(IEnumerable<TEntity> entities, params Expression<Func<TEntity, ICollection<EntityBase>>>[] properties)
        {
            if (entities == null) return entities;

            IQueryable<TEntity> query = entities.AsQueryable();
            foreach (var prop in properties)
            {
                query.ToList().ForEach(x => _context.Entry(x).Collection(prop).Load());
            }
            return query.AsEnumerable();
        }

        public virtual TEntity Include(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            if (entity == null) return entity;

            foreach (var includeProperty in includeProperties)
            {
                _context.Entry(entity).Reference(includeProperty).Load();
            }
            return entity;
        }
        public virtual IEnumerable<TEntity> Include(IEnumerable<TEntity> entities, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (entities == null) return entities;

            IQueryable<TEntity> query = entities.AsQueryable();
            foreach (var prop in includeProperties)
            {
                query.ToList().ForEach(x => _context.Entry(x).Reference(prop).Load());
            }
            return query.AsEnumerable();
        }
        public void ExecuteQuery(string query)
        {
            _context.Database.SqlQuery<TEntity>(query);
        }

        public IEnumerable<TEntity> Query(string query)
        {
            return _context.Database.SqlQuery<TEntity>(query);
        }

        public virtual TEntity Get(long id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            _context?.Dispose();
        }
    }
}