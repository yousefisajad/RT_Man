using FerameworkGeneral.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FerameworkGeneral.Infrastructure
{
    public class RepositoryBase<TKey, TEntity>: IRepository<TKey, TEntity> where TEntity : class
    {
        DbContext _dbContext;

        public RepositoryBase(DbContext dbCOntext)
        {
            _dbContext = dbCOntext;
        }

        public void Create(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Any(expression);
        }

        public TEntity Get(TKey id)
        {
            return _dbContext.Find<TEntity>(id);
        }

        public List<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
