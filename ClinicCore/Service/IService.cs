using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCore.Service
{
    public interface IService<TEntity> where TEntity : class
    {
        public void Add(TEntity entity);
        public void Remove(TEntity entity);
        public TEntity GetOneById(int id);
        public IEnumerable<TEntity> GetAll();

    }
}
