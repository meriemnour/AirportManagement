using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        public UnitOfWork(DbContext cXT)
        {
            this.context = cXT;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity> (context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        //*****Disposable******
        private bool disposedValue;//true si c deja libéré sinon false
        protected virtual void Dispose(bool disposing)// disposing true en cour de libération sinon false
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
            //bc : garbage collector   supperss tfasakh mel gc
        }
    }
}
