using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Pharmacy.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Save();
        void Update(TEntity entity);
        void Add(TEntity entity);
        void Remove(TEntity entity);

    }
}
