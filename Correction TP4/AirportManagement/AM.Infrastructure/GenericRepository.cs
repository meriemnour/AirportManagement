using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext context;
        private DbSet<T> dbSet;
        public GenericRepository(DbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T> ();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            //throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            //throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            dbSet.RemoveRange(dbSet.Where(where));
            //throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return
                dbSet.Where(where).FirstOrDefault();

            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
            //throw new NotImplementedException();
        }

        public T GetById(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return dbSet.Where(where);
            else
                return dbSet.AsEnumerable();
            //throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            //throw new NotImplementedException();
        }
    }
}
