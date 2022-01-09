using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ClinicCore.Storages
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Save();

        void Add(TEntity entity);
        void Remove(TEntity entity);

    }
}
