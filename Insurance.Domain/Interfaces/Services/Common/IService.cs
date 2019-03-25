using System;
using System.Collections.Generic;

namespace Insurance.Domain.Interfaces.Services.Common
{
    public interface IService<TEntity> : IDisposable
        where TEntity : class
    {
        TEntity Get(long id);
        IEnumerable<TEntity> All();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
