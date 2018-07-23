using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PurchaseControlSystem.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAllList();
        void Save();
    }
}