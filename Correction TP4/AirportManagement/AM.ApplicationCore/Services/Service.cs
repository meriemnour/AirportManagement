using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class Service<T>:IService<T> where T : class 
    {
        private IGenericRepository<T> repository;
        private IUnitOfWork unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            this.repository = unitOfWork.Repository<T>();
            this.unitOfWork = unitOfWork;
        }
        public virtual void Add(T entity)
        {
            repository.Add(entity);
        }
        public virtual void Update(T entity)
        {
            repository.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            repository.Delete(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            repository.Delete(where);
        }

        public virtual T GetById(params object[] keyValues)
        {
            return repository.GetById(keyValues);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null)
        {
            return repository.GetMany(filter);
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return repository.Get(where);
        }
        public void Commit()
        {
            try
            {
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
