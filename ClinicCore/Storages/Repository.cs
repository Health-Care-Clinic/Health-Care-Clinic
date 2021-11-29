
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClinicCore.Storages
{
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            protected readonly DbContext Context;

            public Repository(DbContext context)
            {
                Context = context;
            }

            public void Add(TEntity entity)
            {
                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();
            }

            public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            {
                return Context.Set<TEntity>().Where(predicate);
            }

            public IEnumerable<TEntity> GetAll()
            {
                return Context.Set<TEntity>().ToList();
            }

            public TEntity GetById(int id)
            {
                return Context.Set<TEntity>().Find(id);
            }

            public void Remove(TEntity entity)
            {
                Context.Set<TEntity>().Remove(entity);
                Save();
            }

            public void Save()
            {
                Context.SaveChanges();
            }
        }
}
