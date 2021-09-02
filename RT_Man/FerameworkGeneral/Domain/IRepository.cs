using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FerameworkGeneral.Domain
{
    public interface IRepository<TKey, TEntity> where TEntity : class
    {
        TEntity Get(TKey id);
        List<TEntity> Get();
        void Create(TEntity entity);
        void SaveChanges();
        bool Exists(Expression<Func<TEntity, bool>> expression);
    }
}
