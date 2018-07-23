using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PurchaseControlSystem.Data.Contracts;

namespace PurchaseControlSystem.Data.Repositories
{
    public abstract class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        protected readonly PurchaseControlDbContext Context;

        public Repository(PurchaseControlDbContext context)
        {
            this.Context=context;

        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public abstract void Delete(TEntity entity);
        

        public TEntity GetById(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAllList()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}